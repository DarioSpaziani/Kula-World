using _01_Scripts.Audio;
using UnityEngine;

namespace _01_Scripts
{
    public class SkinManager : MonoBehaviour
    {
        public static int skinSelected;
        
        public GameObject[] selectors;
        
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            selectors[0].SetActive(true);
            skinSelected = 0;
        }

        public void SetSkin(int skinNumber)
        {
            audioManager.PlayButtonPressed();
            skinSelected = skinNumber;
            selectors[skinNumber].SetActive(true);

            for (int i = 0; i < selectors.Length; i++) {
                if (i != skinNumber) {
                    selectors[i].SetActive(false);
                }
            }
        }
    }
}
