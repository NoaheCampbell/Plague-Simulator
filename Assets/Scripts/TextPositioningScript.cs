using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPositioningScript : MonoBehaviour
{
    public Text infectedPeopleText;
    public Text immunePeopleText;
    public Text unInfectedPeopleText;
    public GameMaster gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        infectedPeopleText.text = "Infected People: " + gameMaster.infectedPeople;
        immunePeopleText.text = "Immune People: " + gameMaster.immunePeople;
        unInfectedPeopleText.text = "Uninfected People: " + gameMaster.unInfectedPeople;   
    }

}
