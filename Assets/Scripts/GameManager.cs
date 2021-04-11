﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameSpeed = 1.5f;
    private void Awake()
    {
        Time.timeScale = gameSpeed;
        //SetUpSingleton();  
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
        //Debug.Log("game speed=  " + gameSpeed);
    }
    IEnumerator GameOverSceneLoading()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 0f;
        TimeControl.instance.GameOver();
        UIManager.instance.GameOverScene();

    }
}
