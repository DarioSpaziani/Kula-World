using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerGame : MonoBehaviour
{
    private float initTime;
    public int levelTime;

    public bool isGameFinished;
    
    public bool isTimePaused;
    
    public TextMeshProUGUI timerText;

    private Manager manager;

    public SO_Bonus soBonus;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        StartCoroutine(TimeRoutine());
    }


    private IEnumerator TimeRoutine()
    {
        initTime = Time.time;

        while (Time.time < levelTime + initTime)
        {
            if (!isTimePaused)
            {
                timerText.text = "TIME: " + (levelTime + initTime - Time.time).ToString("0.00");
            }
            else
                timerText.text = "BONUS TIME!!";

            yield return null;
        }

        if (!isGameFinished)
        {
            manager.ball.GetComponentInParent<Movement>().enabled = false;
            manager.ball.SetActive(false);
            manager.finishTab.SetActive(true);
            manager.finishText.text = "TIME IS OVER!";
        }
    }
    
    public void PauseTime()
    {
        isTimePaused = true;
        StartCoroutine(StopPause());
    }
    
    private IEnumerator StopPause()
    {
        yield return new WaitForSeconds(soBonus.bonusTime);
        isTimePaused = false;
        initTime += soBonus.bonusTime;
    }
}
