using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            var personPos = collision.gameObject.transform.position;
            collision.gameObject.transform.position = new Vector3(personPos.x, transform.position.y + 0.5f, personPos.z);
        }
    }
}
