using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraControllerMode { V1,V2}
[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    public CameraControllerMode ccm = CameraControllerMode.V1;
    public GameObject positionTarget;
    public GameObject lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ccm == CameraControllerMode.V1)
            V1();
    }
    void V1()
    {
        if (positionTarget)
            transform.position = positionTarget.transform.position;
        if (lookAtTarget)
            transform.LookAt(lookAtTarget.transform, Vector3.up);
    }
}
