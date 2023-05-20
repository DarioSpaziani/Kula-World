using System.Collections;
using TMPro;
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

    public Material[] skins;

    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        
        finishTab.SetActive(false);
        ball.GetComponent<MeshRenderer>().sharedMaterial = skins[SkinManager.skinSelected];

        scoreToReach = FindObjectsOfType<Bottle>().Length;
        canFinish = false;
        mExit.sharedMaterial.color = Color.red;

        StartCoroutine(PointRoutine());
    }

    private IEnumerator PointRoutine()
    {
        while (actualScore != scoreToReach)
        {
            yield return null;
        }

        audioManager.PlayWinSound();
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
        ball.GetComponentInParent<CharacterController>().enabled = false;
        ball.SetActive(false);
        finishTab.SetActive(true);
    }

    public void Restart()
    {
        audioManager.PlayButtonPressed();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackLevel()
    {
        audioManager.PlayButtonPressed();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void NextLevel()
    {
        audioManager.PlayButtonPressed();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMenu()
    {
        audioManager.PlayButtonPressed();
        
        SceneManager.LoadScene(0);
    }

    public void InitDie()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        audioManager.PlayLoseSound();
        
        finishText.text = "YOU DIED! RETRY.";
        ball.GetComponentInParent<CharacterController>().enabled = false;
        ball.SetActive(false);

        yield return new WaitForSeconds(1f);

        finishTab.SetActive(true);
    }

}