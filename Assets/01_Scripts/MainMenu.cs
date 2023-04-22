using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        DontDestroyOnLoad(audioManager);
    }

    public void StartGame() {
        audioManager.PlayBonusSound();
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        audioManager.PlayLoseSound();
        Application.Quit();
    }

}
