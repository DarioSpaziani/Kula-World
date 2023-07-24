using _01_Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _01_Scripts
{
    public class TriggerMenu : MonoBehaviour
    {
        public Canvas mainMenu;

        public Canvas skinMenu;

        public Canvas optionMenu;

        private AudioManager audioManager;

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }


        private void Start()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            string sceneName = currentScene.name;
            if (sceneName != "00_Menu")
            {
                mainMenu.gameObject.SetActive(false);
                skinMenu.gameObject.SetActive(false);
                optionMenu.gameObject.SetActive(false);
            }
            else
            {
                mainMenu.gameObject.SetActive(true);
                skinMenu.gameObject.SetActive(false);
                optionMenu.gameObject.SetActive(false);
            }
        
        }

        public void BackToMainMenu()
        {
            audioManager.PlayButtonPressed();
            
            mainMenu.gameObject.SetActive(true);
            skinMenu.gameObject.SetActive(false);
            optionMenu.gameObject.SetActive(false);
        }

        public void SkinMenu()
        {
            audioManager.PlayButtonPressed();
        
            mainMenu.gameObject.SetActive(false);
            skinMenu.gameObject.SetActive(true);
            optionMenu.gameObject.SetActive(false);
        }
    
        public void OptionMenu()
        {
            audioManager.PlayButtonPressed();
        
            mainMenu.gameObject.SetActive(false);
            skinMenu.gameObject.SetActive(false);
            optionMenu.gameObject.SetActive(true);
        }
    }
}
