using UnityEngine;

public class rotateController : MonoBehaviour
{
    Vector3 center = new Vector3(0, 0, 0);
    void Update()
    {
        this.transform.RotateAround(center, Vector3.up, (Input.GetAxis("Mouse X") * 5));
        this.transform.RotateAround(center, transform.right, Input.GetAxis("Mouse Y") * -5);
    }
}
