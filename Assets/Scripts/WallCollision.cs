using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Person")
        {
            other.gameObject.GetComponent<PersonScript>().ChangeDirection();
        }
        else if (other.gameObject.tag == "Boundary")
        {
            Physics.IgnoreCollision(other, mainCamera.GetComponent<Collider>());
        }
        else 
        {
            Debug.Log(other.gameObject.tag);
        }
    }

    IEnumerator CameraCollision()
    {
        var timerLeft = 500f;

        mainCamera.GetComponent<CameraScript>().canMoveZ = false;

        while (timerLeft > 0)
        {
            if (mainCamera.GetComponent<CameraScript>().person.transform.position.z > mainCamera.transform.position.z + 15f)
            {
                mainCamera.GetComponent<CameraScript>().canMoveZ = true;
                Debug.Log("Can move Z");
                yield break;
            }

            else
            {
                // Debug.Log(mainCamera.GetComponent<CameraScript>().person.transform.position.z);
            }
            timerLeft -= 0.5f;
        }
    }
}
