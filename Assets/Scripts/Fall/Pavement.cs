using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavement : MonoBehaviour
{
    BoxCollider boxCollider;
    public float colliderWait = 5f;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        StartCoroutine(WaitForCollider());
    }

    IEnumerator WaitForCollider()
    {
        yield return new WaitForSeconds(colliderWait);
        boxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().IsGameLost = true;
        }
    }
}
