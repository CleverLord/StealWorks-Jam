using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float mouseSpeedX = 1;
    public float mouseSpeedY = 1;
    public bool invertY;
    CharacterController cc;
    public GameObject cameraPivot;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSpeedX);
        cameraPivot.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * mouseSpeedY * (invertY ? 1:-1));
    }
    void UpdatePosition()
    {
        Vector3 v3In = transform.right* Input.GetAxis("Horizontal")+ transform.forward* Input.GetAxis("Vertical");
        //transform.Translate(v3In * speed*Time.deltaTime);
        cc.SimpleMove(v3In * speed);
    }
}
