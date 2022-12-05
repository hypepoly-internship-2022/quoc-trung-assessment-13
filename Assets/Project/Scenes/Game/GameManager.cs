using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SS.View;

public class GameManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] float timeLeft;
    [SerializeField] GameObject goalGameObject;
    public bool timerOn = true;


    private void Awake()
    {
        timerOn = true;

    }
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        SetGameManagerGameState();
    }
    public void SetGameManagerGameState()
    {
        CountDownTimer(); ;
    }
    public void Loose()
    {
        displayText.text = "You Lose";
        Manager.Add(ResultController.RESULT_SCENE_NAME,0);
        DeactivePlayerAndEnemy();
        goalGameObject.SetActive(false);
    }
    public void Win()
    {
        displayText.text = "You Win";
        Manager.Add(ResultController.RESULT_SCENE_NAME,3);
        DeactivePlayerAndEnemy();
    }
   
    void CountDownTimer()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            { 
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        displayText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    void DeactivePlayerAndEnemy()
    {
        enemy.gameObject.GetComponent<Enemy>().enabled = false;
        playerController.gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.SetActive(false);
    }
}
