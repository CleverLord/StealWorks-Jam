using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float mouseSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        UpdatePosition();
    }
    void UpdatePosition()
    {
        Vector3 v3In = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(v3In * speed*Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X")*mouseSpeed);
    }
}
