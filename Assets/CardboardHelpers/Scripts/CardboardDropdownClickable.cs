using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// cardboard ui input hack 
// use XR Interaction Toolkit Interactor to detect pointer enter/exit (hover)
// add this script to a Dropdown UI element to handle clicks. 
// requires theres also a XRCardboardController in the scene
public class CardboardDropdownClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
//ISelectHandler, IPointerClickHandler, 
{
    private Dropdown _dropdown;

    void Start()
    {
        _dropdown = GetComponent<Dropdown>();
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

    // TODO: fix click event
    private void OnClick() {
        _dropdown.OnPointerClick(new PointerEventData(EventSystem.current));
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("**** OnPointerClick");
        _dropdown.OnPointerClick(eventData);
    }

    //public void OnSelect(BaseEventData eventData)
    //{
    //    Debug.Log("**** OnSelect");
    //}
}
