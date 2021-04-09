using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFall : MonoBehaviour
{
    FallControl fallControl;
    float fallDistance = 5f;

    private void Start()
    {
        fallControl = FindObjectOfType<FallControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fallControl.Fall(fallDistance);
        }
    }
}
