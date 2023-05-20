using System;
using UnityEngine.UI;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    public Image uiBottle;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            audioManager.PlayBottleSound();
            
            uiBottle.color = Color.white;
            Manager.Instance.Score();
            Destroy(gameObject); 
        }
    }
}
