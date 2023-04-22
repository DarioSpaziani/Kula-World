﻿using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    private int actualScore;
    private int scoreToReach;
    public int bonusTime;
    public int levelTime;
    private float initTime;

    public bool isGameFinished, canFinish;
    public bool isTimePaused;

    public GameObject finishTab;
    public GameObject ball;

    public MeshRenderer mExit;

    public TextMeshProUGUI finishText;
    public TextMeshProUGUI timerText;

    public Material[] skins;

    private AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        finishTab.SetActive(false);
        ball.GetComponent<MeshRenderer>().sharedMaterial = skins[SkinManager.skinSelected];

        scoreToReach = FindObjectsOfType<Bottle>().Length;
        mExit.sharedMaterial.color = Color.red;

        StartCoroutine(MainRoutine());
    }
    

    private IEnumerator MainRoutine()
    {
        StartCoroutine(TimeRoutine());

        while (actualScore != scoreToReach)
        {
            yield return null;
        }

        canFinish = true;
        mExit.sharedMaterial.color = Color.green;
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
            audioManager.PlayLoseSound();
            ball.GetComponentInParent<Movement>().enabled = false;
            ball.SetActive(false);
            finishTab.SetActive(true);
            finishText.text = "TIME IS OVER!";
        }
    }

    public void PauseTime()
    {
        if (audioManager == null)
        {
            
        }
        audioManager.PlayBonusSound();
        isTimePaused = true;
        StartCoroutine(StopPause());
    }

    private IEnumerator StopPause()
    {
        yield return new WaitForSeconds(bonusTime);
        isTimePaused = false;
        initTime += bonusTime;
    }

    public void Score()
    {
        audioManager.PlayBottleSound();
        actualScore++;
    }

    public void FinishLevel()
    {
        audioManager.PlayWinSound();
        isGameFinished = true;
        finishText.text = "YOU WIN!";
        ball.GetComponentInParent<Movement>().enabled = false;
        ball.SetActive(false);
        finishTab.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void InitDie()
    {
        
        StartCoroutine(Die());
        audioManager.PlayLoseSound();
    }

    private IEnumerator Die()
    {
        finishText.text = "YOU DIED! RETRY.";
        ball.GetComponentInParent<Movement>().enabled = false;
        ball.SetActive(false);

        yield return new WaitForSeconds(1f);

        finishTab.SetActive(true);
    }
}