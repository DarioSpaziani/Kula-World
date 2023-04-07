using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;

    private float currentVelocity = 0;

    private void Update() {

        float horizontal = 0;
        
        if(Input.GetKey(KeyCode.W))
        {
            horizontal++;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            horizontal--;
        }
        transform.position += new Vector3(horizontal, 0, 0 ) * speed * Time.deltaTime;
    }
}
