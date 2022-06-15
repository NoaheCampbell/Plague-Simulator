using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{
    public PersonMaster personMaster;
    public Spawner spawner;
    public DiseaseMaster diseaseMaster;
    public MeshRenderer meshRenderer;
    public Material infectedMaterial;
    public Material unInfectedMaterial;
    public Material immuneMaterial;
    private float timeBetweenCalls;
    private bool canMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("PersonParent").transform;
        personMaster = GetComponent<PersonMaster>();
        spawner = GetComponent<Spawner>();
        diseaseMaster = GetComponent<DiseaseMaster>();
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        canMoveForward = true;

        if (!personMaster.isImmuneFromStart)
        {
            var randomNum = Random.Range(0f, 100f);
            if (randomNum < 1)
            {
                personMaster.isImmuneFromStart = true;
                meshRenderer.material = immuneMaterial;
            }
            else
            {
                personMaster.isImmuneFromStart = false;
                meshRenderer.material = unInfectedMaterial;
            }

            if (randomNum > 95)
            {
                personMaster.isInfected = true;
                meshRenderer.material = infectedMaterial;
            }
        }
        
        personMaster.maxTimeAlive += Random.Range(-10f, 10f);
        diseaseMaster.recoveryTime += Random.Range(-10f, 10f);
        personMaster.immuneTime += Random.Range(-10f, 10f);


        transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

        timeBetweenCalls = 30f;

        ResetTimers();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNearbyPeople();

        MoveForward();

        UpdateTimers();

    }

    public void CheckForNearbyPeople()
    {
        if (timeBetweenCalls <= 0)
        {
            var people = GameObject.FindGameObjectsWithTag("Person");

            foreach (GameObject person in people)
            {
                var personPos = person.transform.position;
                if (Mathf.Abs(personPos.x - transform.position.x) <= 0.5 && Mathf.Abs(personPos.z - transform.position.x) <= 0.5)
                {
                    Infect(person);

                    if (personMaster.timeSinceLastSpawn >= personMaster.timeNeededToSpawn)
                    {
                        spawner.Spawn(gameObject, person);
                        personMaster.timeSinceLastSpawn = 0f;
                    }
                }
            }
            timeBetweenCalls = 30f;
        }
        else
        {
            timeBetweenCalls -= 1;
        }
    }

    public void Infect(GameObject person)
    {
        if (!personMaster.isImmuneFromStart)
        {
            if (person.GetComponent<PersonMaster>().isInfected && person.GetComponent<PersonMaster>().canInfect)
            {
                var randomNum = Random.Range(0f, 100f);
                if (randomNum < diseaseMaster.infectionChance)
                {
                    personMaster.isInfected = true;
                    meshRenderer.material = infectedMaterial;
                }
            }
        }
    }

    public void ChangeDirection()
    {
        StartCoroutine(ChangeDirectionCoroutine());
    }

    public void MoveForward()
    {
        if (canMoveForward)
        {
            transform.Translate(transform.forward * Time.deltaTime * personMaster.speed);
        }
    }

    public void UpdateTimers()
    {
        if (personMaster.isInfected)
        {
            if (personMaster.timeSinceInfected < diseaseMaster.incubationTime)
            {
                personMaster.timeSinceInfected += Time.deltaTime;
            }
            else if (personMaster.timeSinceInfected >= diseaseMaster.incubationTime && !personMaster.canInfect)
            {
                personMaster.canInfect = true;
            }

            if (personMaster.timeSinceInfected >= diseaseMaster.recoveryTime)
            {
                SetImmune();
            }
        }
        if (personMaster.isImmune && !personMaster.isImmuneFromStart)
        {
            if (personMaster.timeSinceRecovered >= personMaster.immuneTime)
            {
                SetNormal();
            }
            else
            {
                personMaster.timeSinceRecovered += Time.deltaTime;
            }
        }


        if (personMaster.timeAlive >= personMaster.maxTimeAlive)
        {
            Death();
        }
        else 
        {
            personMaster.timeAlive += Time.deltaTime;
        }

        personMaster.timeSinceLastSpawn += Time.deltaTime;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void ResetTimers()
    {
        personMaster.timeSinceInfected = 0f;
        personMaster.timeSinceRecovered = 0f;
        personMaster.timeSinceLastSpawn = 0f;
        personMaster.timeAlive = 0f;
    }

    public void SetImmune()
    {
        personMaster.isImmune = true;
        personMaster.isInfected = false;
        personMaster.canInfect = false;
        meshRenderer.material = immuneMaterial;
    }

    public void SetNormal()
    {
        personMaster.isImmune = false;
        personMaster.isInfected = false;
        personMaster.canInfect = true;
        meshRenderer.material = unInfectedMaterial;
    }

    IEnumerator ChangeDirectionCoroutine()
    {
        var timerLeft = 10f;
        canMoveForward = false;

        while (timerLeft > 0)
        {
            transform.Translate(-transform.forward * Time.deltaTime * personMaster.speed);
            yield return new WaitForSeconds(0.001f);
            timerLeft -= 0.5f;
        }

        var randomNum = Random.Range(-360f, 360f);

        transform.Rotate(0f, randomNum, 0f);
        canMoveForward = true;
    }
}
