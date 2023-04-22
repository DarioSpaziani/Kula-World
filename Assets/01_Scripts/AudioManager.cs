using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;

    public AudioClip winSound, loseSound, bonusSound, bottleSound;
    
    public void PlayWinSound()
    {
        soundSource.PlayOneShot(winSound);
    }
    
    public void PlayLoseSound()
    {
        soundSource.PlayOneShot(loseSound);
    }
    
    public void PlayBonusSound()
    {
        soundSource.PlayOneShot(bonusSound);
    }
    
    public void PlayBottleSound()
    {
        soundSource.PlayOneShot(bottleSound);
    }
}
