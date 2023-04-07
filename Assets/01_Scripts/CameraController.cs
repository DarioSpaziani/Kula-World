using UnityEngine; 

public class CameraController : MonoBehaviour {

	public GameObject player;

	private void Start() {
		transform.RotateAround(player.transform.position, transform.right, 30);
	}
}
