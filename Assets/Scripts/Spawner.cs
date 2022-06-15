using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject personPrefab;
    [System.NonSerialized] public float spawnChance = 10f;
    [System.NonSerialized] public float maxSpawns = 5f;
    public float currentSpawns = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(GameObject parent, GameObject parent2)
    {
        var randomNum = Random.Range(0f, 100f);
       
        if (randomNum <= spawnChance && currentSpawns < maxSpawns)
        {
            var childPerson = Instantiate(personPrefab, parent.transform.position, Quaternion.identity);

            var parent1Immunity = parent.GetComponent<PersonMaster>().isImmuneFromStart;
            var parent2Immunity = parent2.GetComponent<PersonMaster>().isImmuneFromStart;

            if (parent1Immunity || parent2Immunity)
            {
                if (parent1Immunity && parent2Immunity)
                {
                    childPerson.GetComponent<PersonMaster>().isImmuneFromStart = true;
                    childPerson.GetComponent<PersonScript>().meshRenderer.material = parent.GetComponent<PersonScript>().immuneMaterial;
                }
                else
                {
                    if (Random.Range(0f, 1f) < 0.5f)
                    {
                        childPerson.GetComponent<PersonMaster>().isImmuneFromStart = parent1Immunity;
                    }
                    else
                    {
                        childPerson.GetComponent<PersonMaster>().isImmuneFromStart = parent2Immunity;
                    }
                }
            }

            var parent1Infected = parent.GetComponent<PersonMaster>().isInfected;
            var parent2Infected = parent2.GetComponent<PersonMaster>().isInfected;

            if (parent1Infected || parent2Infected)
            {
                if (parent1Infected && parent2Infected)
                {
                    childPerson.GetComponent<PersonMaster>().isInfected = true;
                    childPerson.GetComponent<PersonScript>().meshRenderer.material = parent.GetComponent<PersonScript>().infectedMaterial;
                }
                else
                {
                    if (Random.Range(0f, 1f) < 0.5f)
                    {
                        childPerson.GetComponent<PersonMaster>().isInfected = parent1Infected;
                    }
                    else
                    {
                        childPerson.GetComponent<PersonMaster>().isInfected = parent2Infected;
                    }

                    if (parent1Infected)
                    {
                        parent2.GetComponent<PersonMaster>().isInfected = true;
                    }
                    else
                    {
                        parent.GetComponent<PersonMaster>().isInfected = true;
                    }
                }
            }

            currentSpawns++;
        }
    }
}
