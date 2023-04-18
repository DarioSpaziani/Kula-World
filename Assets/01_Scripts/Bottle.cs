using UnityEngine.UI;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    public Image uiBottle;
    
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            //uiBottle.color = Color.white;
            print("Score");
            Manager.Instance.Score();
            Destroy(gameObject); 
        }
    }
}
