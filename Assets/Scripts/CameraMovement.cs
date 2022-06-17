using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed;
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
        rotationSpeed = 0.1f;
        speed = 10f;
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
            
            // Handles up and down rotation using arrow keys
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - rotationSpeed, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + rotationSpeed, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

            // Changes the camera's y rotation left and right using the left and right arrow keys
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - rotationSpeed, transform.rotation.eulerAngles.z);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed, transform.rotation.eulerAngles.z);
            }
        }

    }
}
