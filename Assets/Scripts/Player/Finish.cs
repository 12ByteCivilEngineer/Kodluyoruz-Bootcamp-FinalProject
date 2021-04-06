using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject winnerScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            //winnerScreen.SetActive(true);
            FindObjectOfType<UIManager>().NextLevelScreen();
            
            Debug.Log("Değdim");
            
            TimeControl.instance.GameOver();
           
        }
    }
}
