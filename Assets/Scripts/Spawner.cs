using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject personPrefab;
    public float spawnChance = 100f;
    public float maxSpawns = 10f;
    public float currentSpawns = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(GameObject person)
    {
        var randomNum = Random.Range(0f, 100f);
       
        if (randomNum <= spawnChance && currentSpawns < maxSpawns)
        {
            var childPerson = Instantiate(personPrefab, person.transform.position, Quaternion.identity);

            if (person.GetComponent<PersonMaster>().isImmuneFromStart)
            {
                childPerson.GetComponent<PersonMaster>().isImmuneFromStart = true;
                childPerson.GetComponent<MeshRenderer>().material = person.GetComponent<PersonScript>().immuneMaterial;
            }

            currentSpawns++;
        }
    }
}
