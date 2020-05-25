using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateController : MonoBehaviour
{
    Vector3 center = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(center, Vector3.up, (Input.GetAxis("Mouse X") * 5));
        this.transform.RotateAround(center, transform.right, Input.GetAxis("Mouse Y") * -5);
    }
}