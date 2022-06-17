using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Quaternion originalRotation;
    private Vector3 originalPosition;
    public GameObject person;
    public bool canMoveZ;
    public Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        originalPosition = transform.position;
        canMoveZ = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckForPerson();
        }

        if (transform.rotation != originalRotation)
        {
            ResetCameraRotation();
        }

        if (person != null)
        {
            FollowPerson();
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
            }
        }
    }

    public void FollowPerson()
    {
        if (canMoveZ)
        {
            cameraPos = new Vector3(person.transform.position.x, person.transform.position.y + 3, person.transform.position.z - 4);
            transform.position = cameraPos;
        }

        else
        {
            transform.position = new Vector3(person.transform.position.x, person.transform.position.y + 3, transform.position.z);
        }
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

    public void ChangeAllowedDirection()
    {
        canMoveZ = !canMoveZ;
    }
}
