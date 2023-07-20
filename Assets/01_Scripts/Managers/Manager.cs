using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _01_Scripts
{
    public class Manager : Singleton<Manager>
    {
        #region Variables

        private int actualScore;
        private int scoreToReach;
    
        private float initTime;

        public bool canFinish;

        public GameObject finishTab;
        public GameObject ball;
        public GameObject gameUI;
        public GameObject pause;
        public GameObject options;
        
        private TimerGame timerGame;

        public MeshRenderer mExit;

        public TextMeshProUGUI finishText;

        public Material[] skins;

        private AudioManager audioManager;

        #endregion

        private void Start()
        {
            timerGame = FindObjectOfType<TimerGame>();
            
            options.SetActive(false);
            pause.SetActive(false);
            
            audioManager = FindObjectOfType<AudioManager>();

            finishTab.SetActive(false);
            ball.GetComponent<MeshRenderer>().sharedMaterial = skins[SkinManager.skinSelected];

            scoreToReach = FindObjectsOfType<Bottle>().Length;
            canFinish = false;
            mExit.sharedMaterial.color = Color.red;

            StartCoroutine(PointRoutine());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseRektMe();
            }
        }

        private void PauseRektMe()
        {
            pause.SetActive(true);
            timerGame.isGameInPause = true;
            //gameUI.SetActive(false);
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

        public void Resume()
        {
            timerGame.isGameInPause = false;
            pause.SetActive(false);
            gameUI.SetActive(true);
        }

        public void Options()
        {
            pause.SetActive(false);
            options.SetActive(true);
        }

        public void BackToMenu()
        {
            options.SetActive(false);
            pause.SetActive(true);
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
}