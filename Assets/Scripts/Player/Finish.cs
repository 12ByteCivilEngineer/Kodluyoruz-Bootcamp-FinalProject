using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winnerScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            winnerScreen.SetActive(true);
            Debug.Log("Değdim");
            TimeControl.instance.GameOver();
        }
    }
}
