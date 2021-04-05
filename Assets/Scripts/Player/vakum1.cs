using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vakum1 : MonoBehaviour
{
    public GameObject rigthHand;
    
    void Update()
    {
        gameObject.transform.position = rigthHand.transform.position;
    }
}
