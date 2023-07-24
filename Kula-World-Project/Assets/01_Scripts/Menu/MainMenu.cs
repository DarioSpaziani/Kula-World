using _01_Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _01_Scripts
{
    public class MainMenu : MonoBehaviour
    {
        private AudioManager audioManager;
        
        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        public void StartGame() {
            audioManager.PlayButtonPressed();
        
            SceneManager.LoadScene(1);
        }

        public void ExitGame() {
            audioManager.PlayButtonPressed();
        
            Application.Quit();
        }

    }
}
