using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjects : MonoBehaviour {
    public float speedRotation;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1 * speedRotation, 0);
    }
}
