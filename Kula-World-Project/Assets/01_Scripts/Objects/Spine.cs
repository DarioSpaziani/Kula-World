using UnityEngine;

namespace _01_Scripts
{
	public class Spine : MonoBehaviour {
		
		public float speed = 0.01f;
		
		public bool hasTriggered;
		
		private Vector3 startPosition, destination;

		private void Start() {
			startPosition = transform.localPosition;
			destination = startPosition + new Vector3(0, 0.2f, 0);
		}

		private void Update() {
			if (hasTriggered) {
				if (transform.localPosition.y < destination.y) {
					transform.localPosition = new Vector3(startPosition.x, transform.localPosition.y + speed, startPosition.z);
				}
				else {
					hasTriggered = false;
				}
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Player")) {
				hasTriggered = true;
				Manager.instance.InitDie();
			}
		}
	}
}
