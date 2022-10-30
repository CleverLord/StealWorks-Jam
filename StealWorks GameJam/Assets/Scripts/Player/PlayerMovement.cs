using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float mouseSpeedX = 1;
    public float mouseSpeedY = 1;
    public bool invertY;
    private float gSpeed = 0f;
    CharacterController cc;
    public GameObject cameraParent;
    Vector3 lookVector = new Vector3(0,0,0);
    public static float lifeTime = 180;
    public UnityAction onDeath;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        UpdatePosition();
    }
    void UpdatePosition()
    {
        if (!cc.isGrounded)
        {
            gSpeed += Physics.gravity.y * Time.deltaTime;
        } else
        {
            gSpeed = 0;
        }
        Vector3 v3In = cameraParent.transform.right* Input.GetAxis("Horizontal") + cameraParent.transform.forward * Input.GetAxis("Vertical");
        if (v3In.magnitude > 0.01)
            lookVector = v3In;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized, Vector3.up), 0.1f);
        cc.Move((Vector3.ClampMagnitude(v3In, 1) * speed - Vector3.down * gSpeed) * Time.deltaTime);
    }
}
