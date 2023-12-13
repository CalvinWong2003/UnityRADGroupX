using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
}
