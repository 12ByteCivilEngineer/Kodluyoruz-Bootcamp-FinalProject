using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vakum1 : MonoBehaviour
{
    public GameObject rightHand;
    void Update()
    {
        gameObject.transform.position = rightHand.transform.position;
    }
}
