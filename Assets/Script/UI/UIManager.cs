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
    public GameObject pauseScreen;
    public GameObject inGame;
    public GameObject characterDancing; 
    
    public void StartGame()
    {
        InGame();
        
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
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        backGroundImage.SetActive(false);
        mainScreen.SetActive(false);
        settingScreen.SetActive(false);
        characterDancing.SetActive(false);
        inGame.SetActive(true);
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
    public void Pause()
    {
        Time.timeScale = 0f;
        inGame.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void PauseScreenToMenu()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        mainScreen.SetActive(true);
        backGroundImage.SetActive(true);
        characterDancing.SetActive(true);
    }
}
