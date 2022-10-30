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
    [SerializeField] float cameraDistance = 4;
    [SerializeField] float step = 0.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ChangeCameraDistance(Input.GetAxis("Mouse ScrollWheel"));
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
        int layer_mask = LayerMask.GetMask("Terrain");
        RaycastHit hit;
        if (Physics.Raycast(followObject.position, cam.transform.forward * -1, out hit, cameraDistance + 0.5f, layer_mask))
        {
                float dist = hit.distance - 0.5f;
                if (dist > cameraDistance)
                    dist = cameraDistance;
                cam.transform.localPosition = new Vector3(0, 0, -dist);
        }
        else if (cam.transform.localPosition.z < cameraDistance)
        {
            cam.transform.localPosition = new Vector3(0, 0, -cameraDistance);
        }
        cam.transform.LookAt(followObject);
    }

    public void ChangeCameraDistance(float value)
    {
        cameraDistance *= (1 - step * value);
        if (cameraDistance < 0.7f)
        {
            cameraDistance = 0.7f;
        } else if (cameraDistance > 20f)
        {
            cameraDistance = 20f;
        }
    }
}
