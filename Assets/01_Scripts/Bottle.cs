using UnityEngine.UI;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    public Image uiBottle;
    private AudioManager audioManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            uiBottle.color = Color.white;
            audioManager.PlayBottleSound();
            Manager.Instance.Score();
            Destroy(gameObject); 
        }
    }
}
