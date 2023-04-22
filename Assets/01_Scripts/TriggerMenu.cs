using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerMenu : MonoBehaviour
{
    public Canvas mainMenu;

    public Canvas skinMenu;

    public Canvas optionMenu;
    
    
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "01_MainScene")
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
        mainMenu.gameObject.SetActive(true);
        skinMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
    }

    public void SkinMenu()
    {
        mainMenu.gameObject.SetActive(false);
        skinMenu.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
    }
    
    public void OptionMenu()
    {
        mainMenu.gameObject.SetActive(false);
        skinMenu.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(true);
    }
}
