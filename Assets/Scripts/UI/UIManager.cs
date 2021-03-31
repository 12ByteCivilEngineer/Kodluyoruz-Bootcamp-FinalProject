using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject settingScreen;   
    public GameObject mainScreen;
    public GameObject backGroundImage;
    public GameObject gameOverScreen;
    public GameObject mainMenuScreen;
    public GameObject inGame;
    public GameObject characterDancing;   
    
    public void StartGame()
    {
        InGame();
        inGame.SetActive(true);
        gameOverScreen.SetActive(false);
        //Game Start
        //SceneManager.LoadScene(1);
        Debug.Log("oyun başlıyor.");
    }
    public void Setting()
    {
        StartCoroutine(SettingButtonAnimDelay());
    }
    public void SettingtoMenu()
    {
        mainScreen.SetActive(true);
        settingScreen.SetActive(false);
        characterDancing.SetActive(true);
    }    
    public void Exit()
    {
        Debug.Log("Çıkış Yapılıyor");
        Application.Quit();
    }
    public void InGame()
    {
        backGroundImage.SetActive(false);
        mainScreen.SetActive(false);
        settingScreen.SetActive(false);
        characterDancing.SetActive(false);
    }
    IEnumerator SettingButtonAnimDelay()
    {
        yield return new WaitForSeconds(.3f);
        mainScreen.SetActive(false);
        settingScreen.SetActive(true);
        characterDancing.SetActive(false);
    }
    public void NextLevel()
    {
        Debug.Log("Next Level!");
    }
    public void GameOverScreenToMain()
    {
        gameOverScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
