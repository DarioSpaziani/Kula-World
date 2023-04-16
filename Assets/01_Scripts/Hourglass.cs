using UnityEngine;

public class Hourglass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Manager.Instance.PauseTime();
            Destroy(gameObject);
        }
    }
}
