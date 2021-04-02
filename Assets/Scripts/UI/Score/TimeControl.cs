using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public static TimeControl instance;
    public Text timeCounter;
    public Text gameOverText;
    public Text highScoreText;
    public Text winnerText;
    public Text winnerHighScoreText;

    bool gamePlaying;
    float highScore;
    TimeSpan timePlaying;    
    private float elapsedTime, startTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //timeCounter.text = "Time: 00:00.00";
        //timerGoing = false;
        TimeControl.instance.BeginTimer(); //Start
        
    }
    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time- startTime;
            //timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + elapsedTime.ToString("00");
            timeCounter.text = timePlayingStr;
        }
    }
    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }
    public void BeginTimer()
    {
        elapsedTime = 0f;
    }
   
    public void GameOver()
    {
        gamePlaying = false;
        string timePlayingStr = elapsedTime.ToString("00");
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        if (highScore>elapsedTime)
        {
            highScore = elapsedTime; 
            PlayerPrefs.SetFloat("HighScore", elapsedTime);
        }
        gameOverText.text ="Score : "+ elapsedTime.ToString("00");
        winnerText.text= "Score : " + elapsedTime.ToString("00");
        highScoreText.text = "HighScore : " + highScore.ToString("00");
        winnerHighScoreText.text = "HighScore : " + highScore.ToString("00");
    }

}
