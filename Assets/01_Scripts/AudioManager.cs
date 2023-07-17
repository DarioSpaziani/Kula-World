using System.Collections;
using UnityEngine;

namespace _01_Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioSource sfxAudioSource;
        public float timerModifyVolume;
    
        public AudioClip musicSound, winSound, loseSound, bonusSound, bottleSound;
        public AudioClip buttonPressedSound, jumpSound,exitLevelSound;

        public void PlayJumpSound()
        {
            sfxAudioSource.clip = jumpSound;
            audioSource.PlayOneShot(jumpSound);
        }

        public void PlayWinSound()
        {
            sfxAudioSource.clip = winSound;
            audioSource.PlayOneShot(winSound);
        }
    
        public void PlayLoseSound()
        {
            sfxAudioSource.clip = loseSound;
            audioSource.PlayOneShot(loseSound);
        }
    
        public void PlayBonusSound()
        {
            sfxAudioSource.clip = bonusSound;
            audioSource.PlayOneShot(bonusSound);
        }
    
        public void PlayBottleSound()
        {
            sfxAudioSource.clip = bottleSound;
            audioSource.PlayOneShot(bottleSound);
        }

        public void PlayButtonPressed()
        {
            sfxAudioSource.clip = buttonPressedSound;
            audioSource.PlayOneShot(buttonPressedSound);
        }

        public void PlayExitLevel()
        {
            sfxAudioSource.clip = exitLevelSound;
            audioSource.PlayOneShot(exitLevelSound);
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
