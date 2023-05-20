using System;
using UnityEngine;

public class RotationObjects : MonoBehaviour {
    public float speedRotation;

    void Update()
    {
        transform.Rotate(0, 1 * speedRotation, 0);
    }
}
