using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Vector3 corner1;
    public Vector3 corner2;
    public Vector3 corner3;
    public Vector3 corner4;
    public bool canMove;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        corner1 = new Vector3(-52, 0, 18);
        corner2 = new Vector3(19, 0, 18);
        corner3 = new Vector3(19, 0, -52);
        corner4 = new Vector3(-52, 0, -52);
        canMove = true;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && canMove)
        {
            // Handles basic WASD movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            
            // Handles up and down movement using arrow keys
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }

            // Rotates the camera's y axis left and right using the left and right arrow keys
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(transform.up, -speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(transform.up, speed * Time.deltaTime);
            }
        }

    }
}
