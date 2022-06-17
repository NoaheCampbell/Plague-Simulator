using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMaster : MonoBehaviour
{
    [Header("Person")]
    public float speed = 5f;
    public bool isImmune = false;
    public bool isInfected = false;
    public bool isRecovered = false;
    public float timeSinceInfected = 0f;
    public float timeSinceRecovered = 0f;
    public float immuneTime = 20f;
    public bool canInfect = false;
    public bool isImmuneFromStart = false;
    public float timeSinceLastSpawn = 0f;
    public float timeNeededToSpawn = 5f;
    [System.NonSerialized] public float maxTimeAlive = 120f;
    public float timeAlive = 0f;
    public bool cameraIsFollowing = false;
}
