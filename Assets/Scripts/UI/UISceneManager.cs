using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneManager : MonoBehaviour
{
    public GameObject uiScene;
    public GameObject inGameScene;

    private void Start()
    {
        inGameScene.SetActive(false);
    }
    public void StartButtonClick()
    {
        //uiScene.SetActive(false);
        inGameScene.SetActive(true);
    }
}
