using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject[] selectors;
    public static int skinSelected;

    private void Start() {
        selectors[0].SetActive(true);
        skinSelected = 0;
        DontDestroyOnLoad(AudioManager.Instance);
    }

    public void StartGame() {
        AudioManager.Instance.PlayBonusSound();
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        AudioManager.Instance.PlayLoseSound();
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
