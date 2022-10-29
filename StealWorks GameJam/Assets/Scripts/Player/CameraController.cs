using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    public GameObject positionTarget;
    public GameObject lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (positionTarget)
            transform.position = positionTarget.transform.position;
        if (lookAtTarget)
            transform.LookAt(lookAtTarget.transform, Vector3.up);
    }
}
