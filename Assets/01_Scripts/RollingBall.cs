using UnityEngine;

public class RollingBall : MonoBehaviour {
	public void Roll(float step) {
		transform.Rotate(0, 0, step);
	}
}

