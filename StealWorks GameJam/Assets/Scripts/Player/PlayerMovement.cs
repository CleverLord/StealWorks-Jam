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
    CharacterController cc;
    public GameObject cameraParent;
    Vector3 lookVector = new Vector3(0,0,0);
    public static float lifeTime = 180;
    public UnityAction onGameOver; //lose
    public bool dead = false; //win

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnDead()
    {
        dead = true;
    }
    // Update is called once per frame
    
    void Update()
    {
        UpdatePosition();
        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSpeedX);
        //cameraPivot.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * mouseSpeedY * (invertY ? 1:-1));
    }
    Vector3 v3In;
    void UpdatePosition()
    {
        if (!dead)
        {
            v3In = cameraParent.transform.right * Input.GetAxis("Horizontal") + cameraParent.transform.forward * Input.GetAxis("Vertical");
            if (v3In.magnitude > 0.01)
                lookVector = v3In;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized, Vector3.up), 0.1f);
        //transform.Translate(v3In * speed*Time.deltaTime);
        cc.SimpleMove(v3In * speed);
    }
}
