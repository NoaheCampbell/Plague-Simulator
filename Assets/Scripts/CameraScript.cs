using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private CameraMovement cameraMovement;
    public GameObject person;
    public Vector3 cameraPos;
    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = GetComponent<CameraMovement>();
        originalRotation = transform.rotation;
        originalPosition = transform.position;
        isFollowing = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckForPerson();
        }

        if (isFollowing)
        {
            FollowPerson();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StopFollowing();
        }

        if (person == null && isFollowing)
        {
            StopFollowing();
        }
    }

    public void CheckForPerson()
    {
        RaycastHit hit = new RaycastHit();
        bool hitSomething = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

        if (hitSomething)
        {
            if (hit.transform.gameObject.tag == "Person")
            {
                person = hit.transform.gameObject;
                isFollowing = true;
                cameraMovement.canMove = false;
            }
        }
    }

    public void FollowPerson()
    {
        cameraPos = new Vector3(person.transform.position.x, person.transform.position.y + 3, person.transform.position.z - 4);
        transform.position = cameraPos;
    }

    public void ResetCamera()
    {
        gameObject.transform.SetParent(null);
        transform.position = originalPosition;
    }

    public void ResetCameraRotation()
    {
        transform.rotation = originalRotation;
    }

    public void PutCameraInPosition()
    {
        transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
    }

    public void StopFollowing()
    {
        isFollowing = false;
        person = null;
        cameraMovement.canMove = true;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
