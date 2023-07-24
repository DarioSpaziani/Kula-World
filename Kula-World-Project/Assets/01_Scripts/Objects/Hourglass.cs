using _01_Scripts.Audio;
using UnityEngine;

namespace _01_Scripts
{
    public class Hourglass : MonoBehaviour
    {
        private TimerGame timerGame;
        
        private AudioManager audioManager;
    
        private void Start()
        {
            timerGame = FindObjectOfType<TimerGame>();
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                audioManager.PlayBonusSound();
                timerGame.BonusTime();
                Destroy(gameObject);
            }
        }
    }
}
