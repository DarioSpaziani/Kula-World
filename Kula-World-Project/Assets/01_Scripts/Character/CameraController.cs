using UnityEngine;

namespace _01_Scripts
{
	public class CameraController : MonoBehaviour {

		public GameObject player;

        private Camera cam;
        private void Start()
        {
            transform.RotateAround(player.transform.position, transform.right, 30);
            cam = GetComponent<Camera>();
            cam.fieldOfView = 80f;
        }
    }
}
