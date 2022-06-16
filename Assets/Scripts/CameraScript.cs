using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            bool hitSomething = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

            if (hitSomething)
            {
                if (hit.transform.gameObject.tag == "CameraBound")
                {
                    SetPerson(hit.transform.parent.gameObject);
                }
            }
        }
    }

    public void SetPerson(GameObject person)
    {
        transform.SetParent(person.transform);

        transform.position = transform.parent.Find("CameraPosition").position;
        transform.rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
    }

    public void ResetCamera()
    {
        gameObject.transform.SetParent(null);
        transform.position = new Vector3(-17, 23, -66);
    }
}
