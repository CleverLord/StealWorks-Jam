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
    public static float lifeTime = 120;
    public UnityEvent onDeadTouchedGround; 
    public bool dead = false; 
    public bool deadTouchedGround = false;
    public UnityEvent onTimeout;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Die()
    {
        dead = true;
    }
    public void Die2()
    {
        this.enabled = false;
        cc.enabled = false;
        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.down * gSpeed;
    }
    // Update is called once per frame
    
    void Update()
    {
        if ( (dead && cc.isGrounded || Time.time>lifeTime ) && !deadTouchedGround )
        {
            deadTouchedGround = true;
            Die2();
            onDeadTouchedGround?.Invoke();
        }

        if (deadTouchedGround) return;
        UpdatePosition();
        
        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSpeedX);
        //cameraPivot.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * mouseSpeedY * (invertY ? 1:-1));
    }
    Vector3 v3In;
    void UpdatePosition()
    {
        if (!dead)
        {
            if (!cc.isGrounded)
                gSpeed += (Time.deltaTime * Physics.gravity.y);
            else
                gSpeed = 0f;
        }
        if (!dead)
        {
            v3In = cameraParent.transform.right * Input.GetAxis("Horizontal") + cameraParent.transform.forward * Input.GetAxis("Vertical");
            if (v3In.magnitude > 0.01)
                lookVector = v3In;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized, Vector3.up), 0.1f);
        cc.Move((Vector3.ClampMagnitude(v3In, 1) * speed - Vector3.down * gSpeed) * Time.deltaTime);
    }
}
