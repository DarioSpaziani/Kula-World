using System;
using Unity.VisualScripting;
using UnityEngine;
using Timer = System.Threading.Timer;


public class Hourglass : MonoBehaviour
{
    private TimerGame timerGame;
    private void Start()
    {
        timerGame = FindObjectOfType<TimerGame>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            timerGame.PauseTime();
            Destroy(gameObject);
        }
    }
}
