using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int infectedPeople;
    public int immunePeople;
    public int unInfectedPeople;
    public ArrayList people = new ArrayList();
    public float speedOfGame;

    // Start is called before the first frame update
    void Start()
    {
       speedOfGame = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePeople();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedOfGame += 0.5f;
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
}
