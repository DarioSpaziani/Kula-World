using UnityEngine.UI;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    public Image uiBottle;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayBottleSound();
            Manager.Instance.Score();
            Destroy(gameObject); 
        }
    }
}
