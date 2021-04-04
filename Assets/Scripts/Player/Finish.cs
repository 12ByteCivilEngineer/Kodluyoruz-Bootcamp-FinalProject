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
            Time.timeScale = 0f;
            winnerScreen.SetActive(true);
            UIManager.instance.NextLevel();
            Debug.Log("Değdim");
            TimeControl.instance.GameOver();
        }
    }
}
