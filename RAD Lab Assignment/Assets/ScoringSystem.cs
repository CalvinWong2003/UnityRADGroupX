using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMP;

public class ScoringSystem : MonoBehaviour
{
    //Creating an gameobject visible to the code

    public static int theScore;
    
    //To detect the ship's collision when it enters the gameobject
    void Update()
    {
        gameObject.GetComponent<TMP>().text = "SCORE: " + theScore;
    }
}
