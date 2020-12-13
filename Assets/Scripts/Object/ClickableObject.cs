using System;
using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class ClickableObject : MonoBehaviour
    {
        public GameObject obj;
        public UnityEvent onClick = new UnityEvent();

        protected void Start()
        {
            obj = gameObject;
        }
        
        protected void Update () {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
         
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Button Clicked");
                    onClick.Invoke();
                }
            }    
        }
    }
}