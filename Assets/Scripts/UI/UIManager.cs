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
    public GameObject shopScreen;
    public GameObject gameTutorialScreen;
    public GameObject characterDancing;
    public GameObject selectedCharacter;
    public void Start()
    {
        Time.timeScale = 1f;
        mainMenuScreen.SetActive(true);
        inGame.SetActive(false);
    }
    private void Update()
    {
        //Debug.Log(Time.timeScale);
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Tutorial");
        }

    }
    public void StartGame()
    {
        Debug.Log(PlayerPrefs.HasKey("Tutorial"));
        Time.timeScale = GameManager.gameSpeed;
        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            
            gameTutorialScreen.SetActive(true);
            PlayerPrefs.SetInt("Tutorial", 1);
        }       
            InGame();
        
                       
        //gameTutorialScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        
        //Game Start
        //SceneManager.LoadScene(1);
        Debug.Log("oyun başlıyor.");
    }
    public void TutorialToInGame()
    {
        gameTutorialScreen.SetActive(false);
        InGame();
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
        TimeControl.instance.BeginGame();
        Time.timeScale = GameManager.gameSpeed;
        pauseScreen.SetActive(false);
        backGroundImage.SetActive(false);
        mainScreen.SetActive(false);
        settingScreen.SetActive(false);
        characterDancing.SetActive(false);
        inGame.SetActive(true);
        //gameTutorialScreen.SetActive(false);
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
        inGame.SetActive(false);
        gameOverScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        inGame.SetActive(false);
        pauseScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }
    public void PauseScreenToMenu()
    {
        Time.timeScale = 1f;
        inGame.SetActive(false);
        pauseScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        mainScreen.SetActive(true);
        backGroundImage.SetActive(true);
        characterDancing.SetActive(true);
    }
    public void ShopScene()
    {
        selectedCharacter.SetActive(true);
        shopScreen.SetActive(true);
        mainMenuScreen.SetActive(false);    
    }
    public void ShopScreenToMenu()
    {
        selectedCharacter.SetActive(false);
        shopScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    public void GameOverScene()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(true);
        inGame.SetActive(false);
        TimeControl.instance.GameOver();      
    }
}
