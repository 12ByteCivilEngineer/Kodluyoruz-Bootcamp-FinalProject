using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vakum : MonoBehaviour
{
    public GameObject leftHand;
    
    void Update()
    {
        gameObject.transform.position = leftHand.transform.position;
    }
}
