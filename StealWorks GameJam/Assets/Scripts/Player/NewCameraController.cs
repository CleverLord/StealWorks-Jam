using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    [SerializeField] Transform followObject;
    [SerializeField] float mouseSpeedX;
    [SerializeField] GameObject cameraAnchor;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject player;
    [SerializeField] float playerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        transform.position = followObject.transform.position;
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSpeedX);
        cameraAnchor.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -mouseSpeedX, Space.Self);
        if (cameraAnchor.transform.eulerAngles.x < 280 && cameraAnchor.transform.eulerAngles.x > 180)
        {
            // What happens when the angle is smaller than -80
            cameraAnchor.transform.localEulerAngles = new Vector3(280, 0, 0);
        }
        else if (cameraAnchor.transform.eulerAngles.x > 80 && cameraAnchor.transform.eulerAngles.x < 180)
        {
            // What happens when the angle is larger than 80
            cameraAnchor.transform.localEulerAngles = new Vector3(80, 0, 0);
        }
        cam.transform.LookAt(followObject);
    }
}
