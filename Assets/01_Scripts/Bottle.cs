using UnityEngine;

public class Bottle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            print("Score");
            Manager.Instance.Score();
            Destroy(gameObject); 
        }
    }
}
