using System.Collections;
using TMPro;
using UnityEngine;

namespace _01_Scripts
{
    public class TimerGame : MonoBehaviour
    {
        private float initTime;
        
        public int levelTime;

        public bool isGameFinished;
        public bool isTimePaused;
        public bool isGameInPause;

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
                manager.ball.GetComponentInParent<CharacterController>().enabled = false;
                manager.ball.SetActive(false);
                manager.finishTab.SetActive(true);
                manager.finishText.text = "TIME IS OVER!";
            
            }
        }

        public void BonusTime()
        {
            isTimePaused = true;
            StartCoroutine(StopPause());
        }

        public void PauseGame()
        {
            if (isGameInPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private IEnumerator StopPause()
        {
            yield return new WaitForSeconds(soBonus.bonusTime);
            isTimePaused = false;
            initTime += soBonus.bonusTime;
        }
    }
}