using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int infectedPeople;
    public int immunePeople;
    public int unInfectedPeople;
    public ArrayList people = new ArrayList();
    public float gameSpeed;
    public float previousSpeed;

    // Start is called before the first frame update
    void Start()
    {
       gameSpeed = 1f;
       previousSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePeople();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddToSpeed();
            AccountForGameSpeed();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SubtractFromSpeed();
            AccountForGameSpeed();
        }
    }

    public void UpdatePeople()
    {
        infectedPeople = 0;
        immunePeople = 0;
        unInfectedPeople = 0;

        foreach (GameObject person in people)
        {
            if (person.GetComponent<PersonMaster>().isInfected)
            {
                infectedPeople++;
            }
            else if (person.GetComponent<PersonMaster>().isImmune || person.GetComponent<PersonMaster>().isImmuneFromStart)
            {
                immunePeople++;
            }
            else
            {
                unInfectedPeople++;
            }
        }
    }

    public void AddPerson(GameObject person)
    {
        people.Add(person);
    }

    public void RemovePerson(GameObject person)
    {
        people.Remove(person);
    }

    public void AddToSpeed()
    {
        previousSpeed = gameSpeed;
        gameSpeed += 0.1f;
    }

    public void SubtractFromSpeed()
    {
        previousSpeed = gameSpeed;
        gameSpeed -= 0.1f;
    }

    public void AccountForGameSpeed()
    {
        foreach (GameObject person in people)
        {
            var personScript = person.GetComponent<PersonScript>();

            var newGameSpeed = previousSpeed / gameSpeed;
            personScript.personMaster.speed /= newGameSpeed;
            personScript.personMaster.immuneTime *= newGameSpeed;
            personScript.personMaster.maxTimeAlive *= newGameSpeed;
            personScript.personMaster.timeNeededToSpawn *= newGameSpeed;
            personScript.personMaster.timeSinceLastSpawn *= newGameSpeed;
            personScript.personMaster.timeSinceInfected *= newGameSpeed;
            personScript.personMaster.timeSinceRecovered *= newGameSpeed;
            personScript.personMaster.timeAlive *= newGameSpeed;

            personScript.diseaseMaster.infectionChance /= newGameSpeed;
            personScript.diseaseMaster.recoveryChance /= newGameSpeed;
            personScript.diseaseMaster.recoveryTime *= newGameSpeed;
            personScript.diseaseMaster.incubationTime *= newGameSpeed;
        }
    }
}