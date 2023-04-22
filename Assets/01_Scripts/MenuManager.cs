using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject[] selectors;
    public static int skinSelected;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        selectors[0].SetActive(true);
        skinSelected = 0;
    }

    public void StartGame() {
        audioManager.PlayBonusSound();
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        audioManager.PlayLoseSound();
        Application.Quit();
    }

    public void SetSkin(int skinNumber) {
        skinSelected = skinNumber;
        selectors[skinNumber].SetActive(true);

        for (int i = 0; i < selectors.Length; i++) {
            if (i != skinNumber) {
                selectors[i].SetActive(false);
            }
        }
    }
}
