using _01_Scripts.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts
{
    public class Bottle : MonoBehaviour
    {

        public Image uiBottle;
        private AudioManager audioManager;

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                audioManager.PlayBottleSound();
            
                uiBottle.color = Color.white;
                Manager.instance.Score();
                Destroy(gameObject); 
            }
        }
    }
}
