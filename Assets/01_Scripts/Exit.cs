using System;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && Manager.Instance.canFinish) {
            audioManager.PlayExitLevel();
            Manager.Instance.FinishLevel();
        }
    }
}
