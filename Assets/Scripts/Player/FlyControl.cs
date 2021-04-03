using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControl : MonoBehaviour
{
    float flyForce = 100f;

    public void Fly()
    {
        Debug.Log("Uçuyorsun");
        transform.position = transform.position + new Vector3(0f, flyForce * Time.deltaTime, 0f);
    }
}
