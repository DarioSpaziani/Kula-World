using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class Timer : MonoBehaviour {
    public TextMeshProUGUI timerText;
    public int timerDecrease;
    public int startTimer;
    public GameObject ball;

    private void Start() {
        StartCoroutine(Countdown());
    }

    private void Update() {
        
        timerText.text = startTimer.ToString();

        if (startTimer is <= 15 and >= 10) {
            timerText.color = Color.yellow;
        }
        else if(startTimer <= 10 ){
            timerText.color = Color.red;
        }
        if (startTimer < 0) {
            startTimer = 0;
        }
    }

    private IEnumerator Countdown() {
        while (startTimer >= 0) {
            startTimer -= timerDecrease;
            yield return new WaitForSeconds(1f);
        }
    }
}
