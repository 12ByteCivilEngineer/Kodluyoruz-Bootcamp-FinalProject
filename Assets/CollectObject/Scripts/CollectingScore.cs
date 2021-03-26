using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingScore : MonoBehaviour
{
    public GameObject collectScore;
    public static int score;
    
    void Update()
    {
        collectScore.GetComponent<Text>().text = "OBJECT: " + score;
    }
}
