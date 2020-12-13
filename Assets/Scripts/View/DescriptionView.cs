using System.Collections.Generic;
using Config;
using Object;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

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
                Debug.Log("Click");
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
            if (desc.Showing) return;
            GameObject canvas = new GameObject("PopUp-" + id);
            canvas.transform.position = desc.PopUpPosition;
            canvas.transform.rotation = desc.PopUpRotation;
            canvas.transform.localScale = desc.PopUpScale;
            Canvas c = canvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.WorldSpace;
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<GraphicRaycaster>();
            GameObject panel = new GameObject("Panel");
            panel.AddComponent<CanvasRenderer>();
            Text title = panel.AddComponent<Text>();
            title.text = desc.Title;
            Text content = panel.AddComponent<Text>();
            content.text = desc.Content; // FIXME: NullObjectException
            Button close = panel.AddComponent<Button>();
            close.onClick.AddListener(() =>
            {
                ClosePopUp(id);
            });
            panel.transform.SetParent(canvas.transform, false);
            desc.Showing = true;
        }

        private void ClosePopUp(int id)
        {
            GameObject canvas = GameObject.Find("PopUp-" + id);
            if (canvas == null) return;
            Destroy(canvas);
        }

        protected void Start()
        {
            DescriptionContainerConfiguration descriptionContainerConfiguration = gameObject.AddComponent<DescriptionContainerConfiguration>();
            List<int> ids = descriptionContainerConfiguration.Get(containerId)?.Descriptions;
            if (ids == null) return;
            foreach (int id in ids)
            {
                ShowSphere(id);
            }
        }
    }
}
