using System.Collections.Generic;
using Config;
using Object;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using Library;

namespace View
{
    public class DescriptionView : MonoBehaviour
    {
        public int containerId;
        private List<GameObject> m_Sphere;

        // id: ID of Description Configuration
        
        private void ShowSphere(int id)
        {
            DescriptionConfiguration descriptionConfiguration = gameObject.AddComponent<DescriptionConfiguration>();
            Description desc = descriptionConfiguration.Get(id);
            if (desc == null) return;
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.name = "Sphere-" + id;
            Transform sphereTransform = sphere.transform;
            sphereTransform.position = desc.SpherePosition;
            sphereTransform.rotation = desc.SphereRotation;
            sphereTransform.localScale = desc.SphereScale;
            sphere.gameObject.AddComponent<TrackedDeviceGraphicRaycaster>();
            ClickableObject clickableObject = sphere.gameObject.AddComponent<ClickableObject>();
            clickableObject.onClick.AddListener(() =>
            {
                desc = descriptionConfiguration.Get(id);
                if (desc.Showing) ClosePopUp(id);
                else OpenPopUp(id);
            });
            sphere.gameObject.AddComponent<CardboardCObjClickable>();
        }
        
        private void OpenPopUp(int id)
        {
            DescriptionConfiguration descriptionConfiguration = gameObject.AddComponent<DescriptionConfiguration>();
            Description desc = descriptionConfiguration.Get(id);
            if (desc == null) return;
            if (desc.Showing == true) return;

            GameObject canvas = new GameObject("PopUp-" + id);
            canvas.SetActive(false);
            canvas.transform.position = desc.PopUpPosition;
            canvas.transform.rotation = desc.PopUpRotation;
            canvas.transform.localScale = desc.PopUpScale;
            Canvas c = canvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.WorldSpace;
            canvas.AddComponent<CanvasScaler>();
            canvas.GetComponent<CanvasScaler>().dynamicPixelsPerUnit = 100;
            canvas.AddComponent<GraphicRaycaster>();

            GameObject panel = new GameObject("Panel");
            panel.transform.SetParent(canvas.transform, false);
            panel.AddComponent<CanvasRenderer>();

            GameObject titleObject = new GameObject("Title");
            Text title = titleObject.AddComponent<Text>();
            title.text = desc.Title;
            title.font = Resources.Load<Font>("NotoSansCJKjp-Bold");
            title.color = Color.black;
            titleObject.transform.SetParent(panel.transform, false);

            GameObject contentObject = new GameObject("Content");
            Text content = contentObject.AddComponent<Text>();
            content.text = desc.Content;
            content.font = Resources.Load<Font>("NotoSansCJKjp-Regular");
            content.color = Color.black;
            contentObject.transform.SetParent(panel.transform, false);
            contentObject.transform.localPosition = new Vector3(0.0f, -16.0f, 0.0f);

            GameObject closeObject = new GameObject("Close");
            Text closeText = closeObject.AddComponent<Text>();
            GameObject localization = new GameObject();
            localization.AddComponent<Localization>();
            closeText.text = localization.GetComponent<Localization>().GetSingleTranslation("CLOSE");
            Destroy(localization);
            closeText.font = Resources.Load<Font>("NotoSansCJKjp-Light");
            closeText.color = Color.black;
            Button close = closeObject.AddComponent<Button>();
            close.onClick.AddListener(() =>
            {
                ClosePopUp(id);
                desc.Showing = false;
                descriptionConfiguration.Set(id, desc);
            });
            closeObject.transform.SetParent(panel.transform, false);
            closeObject.transform.localPosition = new Vector3(0.0f, -50.0f, 0.0f);

            canvas.SetActive(true);

            desc.Showing = true;
            descriptionConfiguration.Set(id, desc);
        }

        private void ClosePopUp(int id)
        {
            GameObject canvas = GameObject.Find("PopUp-" + id);
            if (canvas == null) return;
            Destroy(canvas);
        }

        protected void Start()
        {
            GameObject init = new GameObject();
            init.AddComponent<DescriptionConfiguration>();
            init.GetComponent<DescriptionConfiguration>().ClearShowing();
            init.AddComponent<DescriptionContainerConfiguration>();
            List<int> ids = init.GetComponent<DescriptionContainerConfiguration>().Get(containerId)?.Descriptions; // FIXME: not work on Android
            if (ids == null) return;
            foreach (int id in ids)
            {
                ShowSphere(id);
            }
            Destroy(init);
        }
    }
}
