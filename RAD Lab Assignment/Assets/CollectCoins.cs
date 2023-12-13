using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        //Add the points through the ScoringSystem + theScore and destroying the gameobject
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
}
