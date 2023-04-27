using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    private int actualScore;
    private int scoreToReach;
    
    private float initTime;

    public bool canFinish;

    public GameObject finishTab;
    public GameObject ball;

    public MeshRenderer mExit;

    public TextMeshProUGUI finishText;
    
    


    private void Start()
    {
        finishTab.SetActive(false);
        

        scoreToReach = FindObjectsOfType<Bottle>().Length;
        mExit.sharedMaterial.color = Color.red;

        StartCoroutine(MainRoutine());
    }

    private IEnumerator MainRoutine()
    {
        

        while (actualScore != scoreToReach)
        {
            yield return null;
        }

        canFinish = true;
        mExit.sharedMaterial.color = Color.green;
    }
    
    public void Score()
    {
        actualScore++;
    }

    public void FinishLevel()
    {
        canFinish = true;
        finishText.text = "YOU WIN!";
        ball.GetComponentInParent<Movement>().enabled = false;
        ball.SetActive(false);
        finishTab.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void InitDie()
    {

        StartCoroutine(Die());
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