using _01_Scripts.Audio;
using UnityEngine;

namespace _01_Scripts
{
    public class Exit : MonoBehaviour
    {
        private AudioManager audioManager;
        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player") && Manager.instance.canFinish) {
                audioManager.PlayExitLevel();
                Manager.instance.FinishLevel();
            }
        }
    }
}
