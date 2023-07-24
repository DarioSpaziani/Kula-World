using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _01_Scripts.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] Slider sliderMusic;
        [SerializeField] Slider sliderSfx;

        [SerializeField] AudioMixer audioMixer;

        private AudioManager audioManager;

        public const string MIXER_MUSIC = "MusicVolume";
        public const string MIXER_SFX = "SFXVolume";


        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();

            if (sliderMusic != null)
            {
                sliderMusic.onValueChanged.AddListener(SetMusicVolume);
            }
            
            if (sliderSfx != null)
            {
                sliderSfx.onValueChanged.AddListener(SetSfxVolume);
            }
        }

        private void Start()
        {
            sliderMusic.value = PlayerPrefs.GetFloat(audioManager.MUSIC_KEY,1f);
            sliderSfx.value = PlayerPrefs.GetFloat(audioManager.SFX_KEY, 1f);
        }

        void OnDisable()
        {
            PlayerPrefs.SetFloat(audioManager.MUSIC_KEY, sliderMusic.value);
            PlayerPrefs.SetFloat(audioManager.SFX_KEY, sliderSfx.value);
        }

        void SetMusicVolume(float value)
        {
            
            audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        }
        
        void SetSfxVolume(float value)
        {
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        }

        void ActiveMusic()
        {
            
        }
        
        void ActiveSFX()
        {
            
        }
    }
}
