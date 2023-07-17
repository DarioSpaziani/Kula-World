using UnityEngine;

namespace _01_Scripts
{
    public class RotationObjects : MonoBehaviour {
        public float speedRotation;

        void Update()
        {
            transform.Rotate(0, 1 * speedRotation, 0);
        }
    }
}
