using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameSpeed = 1.5f;
    private void Awake()
    {
        Time.timeScale = gameSpeed;
        //SetUpSingleton();  
        QualitySettings.vSyncCount = 1;
        //Application.targetFrameRate = 60;
    }
    private bool isGameLost=false;
    public bool IsGameLost
    {
        get
        {
            return isGameLost;
        }
        set
        {
            if (isGameLost != value)
            {
                if (value)
                {
                    StartCoroutine(GameOverSceneLoading());
                    HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();
                    foreach (HandCollisionHandler element in handCollisionHandlers)
                    {
                        element.MinDistance = Mathf.Infinity;
                    }
                }
                isGameLost = value;
            }
        }
    }
    private void Update()
    {

    }
    IEnumerator GameOverSceneLoading()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 0f;
        TimeControl.instance.GameOver();
        UIManager.instance.GameOverScene();

    }
    private void FPSCounter()
    {
        float current = 0;
        current = 1f / Time.deltaTime;
        int avgFrameRate = (int)current;
        Debug.Log(avgFrameRate);
    }
}
