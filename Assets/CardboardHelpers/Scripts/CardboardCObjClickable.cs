using System.Collections;
using System.Collections.Generic;
using Object;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// cardboard ui input hack 
// use XR Interaction Toolkit Interactor to detect pointer enter/exit (hover)
// add this script to a Button UI element to handle clicks. 
// requires theres also a XRCardboardController in the scene
public class CardboardCObjClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
//ISelectHandler, IPointerClickHandler, 
{
    private ClickableObject m_Obj;

    void Start()
    {
        m_Obj = GetComponent<ClickableObject>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("**** OnPointerEnter " + gameObject.name);
        XRCardboardController.Instance.OnTriggerPressed.AddListener(OnClick);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("**** OnPointerExit " + gameObject.name);
        XRCardboardController.Instance.OnTriggerPressed.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        m_Obj.onClick.Invoke();
    }
}