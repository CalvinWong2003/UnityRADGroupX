using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    //Creating an gameobject visible to the code
    public GameObject scoreText;
    public static int theScore;
    
    //To detect the ship's collision when it enters the gameobject
    private void OnTriggerEnter(Collider other)
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
    }
}
