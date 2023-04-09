using System.Collections;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {
	
	public float speed;
	
	private bool isMoving = false;

	private Vector3 rayFrontDirection;
	
	private Vector3 rayDownDirection;
	
	private Vector3 rayFrontDownDirection;
	
	public RollingBall ball;

	private void Start() {
		recalculateRay();
	}

	private void Update() {
		if (Input.GetAxis("Vertical") > 0) {
			move();
		}else if (Input.GetKeyDown(KeyCode.A)) {
			rotateLeft();
		}else if (Input.GetKeyDown(KeyCode.D)) {
			rotateRight();
		}
	}

	bool projectRay(Vector3 dir, float length = 3) {
		int layerMask = 1 << 8;

		RaycastHit hit;
		Vector3 start = transform.position + transform.up / 2;

		if (Physics.Raycast(start, dir, out hit, length, layerMask)) {
			Debug.DrawRay(start, dir * 1000, Color.red);
			return true;
		}else {
			Debug.DrawRay(start, dir * 1000, Color.white);
			return false;
		}
	}

	void recalculateRay() {
		rayFrontDirection = transform.right;
		rayDownDirection = -transform.up;
		rayFrontDownDirection = transform.right - transform.up * 0.5f;
	}

	IEnumerator smoothMove(float offset) {
		Vector3 targetPos = transform.position + transform.right * offset;
		while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
			ball.Roll(-step * 100);
			yield return null;
		}
	}

	IEnumerator moveFront(float offset = 2) {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(smoothMove(offset));
		isMoving = false;
	}
	
	IEnumerator moveUp() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(smoothMove(0.5f));
		Vector3 eulerUpAngle = new Vector3(0, 0, 90);
		yield return StartCoroutine(smoothRotation(eulerUpAngle));
		yield return StartCoroutine(smoothMove(0.5f));
		isMoving = false;
	}

	IEnumerator moveDown() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(smoothMove(1.5f));
		Vector3 eulerDownAngle = new Vector3(0, 0, -90);
		yield return StartCoroutine(smoothRotation(eulerDownAngle));
		yield return StartCoroutine(smoothMove(1.5f));
		isMoving = false; 
	}
	
	void move() {
		recalculateRay();

		if (!projectRay(rayDownDirection, 1.5f)) {
			return;
		}
		if(projectRay(rayFrontDirection, 1.5f)){
			StartCoroutine(moveUp());
		}else if (projectRay(rayFrontDownDirection)) {
			StartCoroutine(moveFront());
		}
		else {
			StartCoroutine(moveDown());
		}

		
	} 
	
	IEnumerator smoothRotation(Vector3 angle) {
		float duration = 10;

		for (int t = 0; t < duration; t++) {
			transform.Rotate(angle / duration);
			yield return null;
		}
	}

	IEnumerator rotateLeftSmooth() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(smoothRotation(new Vector3(0, -90, 0)));
		isMoving = false;
	}
	
	IEnumerator rotateRightSmooth() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(smoothRotation(new Vector3(0, 90, 0)));
		isMoving = false;
	}

	void rotateLeft() {
		StartCoroutine(rotateLeftSmooth());
	}

	void rotateRight() {
		StartCoroutine(rotateRightSmooth()); 
	}
}
