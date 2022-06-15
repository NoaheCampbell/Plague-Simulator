using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseMaster : MonoBehaviour
{
    [Header("Disease")]
    [System.NonSerialized] public float recoveryChance = 80f;
    [System.NonSerialized] public float infectionChance = 90f;
    [System.NonSerialized] public float deathChance = 20f;
    [System.NonSerialized] public float incubationTime = 5f;
    [System.NonSerialized] public float recoveryTime = 40f;

}
