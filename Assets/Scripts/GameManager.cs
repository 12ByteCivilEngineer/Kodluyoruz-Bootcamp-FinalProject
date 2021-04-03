using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameLostText;
    public static float gameSpeed = 2f;
    private void Awake()
    {
        Time.timeScale = gameSpeed;
        //SetUpSingleton();
        gameLostText.SetActive(false);
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
                    gameLostText.SetActive(true);
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
}
