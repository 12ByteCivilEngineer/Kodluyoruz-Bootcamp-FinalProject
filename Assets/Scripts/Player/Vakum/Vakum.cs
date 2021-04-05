using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vakum : MonoBehaviour
{
    public GameObject leftHand;
    void Update()
    {
        gameObject.transform.position = leftHand.transform.position;
    }
}
