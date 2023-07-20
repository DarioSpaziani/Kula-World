using System;
using System.Collections;
using _01_Scripts.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace _01_Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioSource sfxAudioSource;
        public float timerModifyVolume;
    
        public AudioClip musicSound, winSound, loseSound, bonusSound, bottleSound;
        public AudioClip buttonPressedSound, jumpSound,exitLevelSound;

        [SerializeField] private AudioMixer mixer;
        public string MUSIC_KEY = "musicVolume";
        public string SFX_KEY = "sfxVolume";

        void LoadVolume() //Volume saved in VolumeSettings
        {
            float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
            float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
            
            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(sfxVolume) * 20);
        }

        private void Awake()
        {
            LoadVolume();
        }

        public void PlayJumpSound()
        {
            sfxAudioSource.clip = jumpSound;
            sfxAudioSource.PlayOneShot(jumpSound);
        }

        public void PlayWinSound()
        {
            sfxAudioSource.clip = winSound;
            sfxAudioSource.PlayOneShot(winSound);
        }
    
        public void PlayLoseSound()
        {
            sfxAudioSource.clip = loseSound;
            sfxAudioSource.PlayOneShot(loseSound);
        }
    
        public void PlayBonusSound()
        {
            sfxAudioSource.clip = bonusSound;
            sfxAudioSource.PlayOneShot(bonusSound);
        }
    
        public void PlayBottleSound()
        {
            sfxAudioSource.clip = bottleSound;
            sfxAudioSource.PlayOneShot(bottleSound);
        }

        public void PlayButtonPressed()
        {
            sfxAudioSource.clip = buttonPressedSound;
            sfxAudioSource.PlayOneShot(buttonPressedSound);
        }

        public void PlayExitLevel()
        {
            sfxAudioSource.clip = exitLevelSound;
            sfxAudioSource.PlayOneShot(exitLevelSound);
        }
    
        IEnumerator FadeOutFadeInSong() {
            float t = 0;
            float initVolume = audioSource.volume;
            while (t < timerModifyVolume) {
                audioSource.volume = Mathf.Lerp(initVolume,0,t/timerModifyVolume);
                t += Time.deltaTime;
                yield return null;
            }
            audioSource.clip = musicSound;
            audioSource.volume = 0;
            audioSource.Play();
            t = 0;
            yield return new WaitForSeconds(0.2f);
            while (t < timerModifyVolume) {
                audioSource.volume = Mathf.Lerp(0,initVolume,t/timerModifyVolume);
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}
