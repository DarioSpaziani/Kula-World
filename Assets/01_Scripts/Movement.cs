using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

	#region Variables
	
	public float speed;

	private bool isMoving = false;

	private Vector3 rayFrontDirection;

	private Vector3 rayDownDirection;

	private Vector3 rayFrontDownDirection;

	public RollingBall rollingBall;
	
	#endregion
	
	private void Start() {
		RecalculateRay();
	}
	
	private void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			if (Input.GetAxis("Vertical") > 0) {
				JumpAndMove(2);
			}
		}
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			Jump();
		}
		
		if (Input.GetAxis("Vertical") > 0) {
			Move();
		}
		else if (Input.GetKeyDown(KeyCode.A)) {
			RotateLeft();
		}

		else if (Input.GetKeyDown(KeyCode.D)) {
			RotateRight();
		}
	}

	#region Raycast

	private void RecalculateRay() {
		var transform1 = transform;
		var right = transform1.right;
		var up = transform1.up;
		
		rayFrontDirection = right;
		rayDownDirection = -up;
		rayFrontDownDirection = right - up * 0.5f;
		
	}
	
	private bool ProjectRay(Vector3 dir, float length = 3) {
		int layerMask = 1 << 8;

		var transform1 = transform;
		Vector3 start = transform1.position + transform1.up / 2;

		if (Physics.Raycast(start, dir, out RaycastHit _, length, layerMask)) {
			Debug.DrawRay(start, dir * 1000, Color.red);
			return true;
		}
		else 
		{
			Debug.DrawRay(start, dir * 1000, Color.green);
			return false;
		}
	}

	GameObject getRayHit(Vector3 start, Vector3 dir, float length = 3) {
		int layerMask = 1 << 8;

		RaycastHit hit;

		if (Physics.Raycast(start, dir, out hit, length, layerMask)) {
			Debug.DrawRay(start, dir * 1000, Color.red);
			return hit.collider.gameObject;
		}
		else {
			Debug.DrawRay(start, dir * 1000, Color.white);
			return null;
		}
	}
	
	#endregion
	
	#region Movement
	
	private IEnumerator SmoothMove(float offset) {
		Transform transform1 = transform;
		Vector3 targetPos = transform1.position + transform1.right * offset;
		while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
			rollingBall.Roll(-step * 100);
			yield return null;
		}
	}

	private IEnumerator MoveFront(float offset = 2) {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(SmoothMove(offset));
		isMoving = false;
	}

	private IEnumerator MoveUp() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(SmoothMove(0.5f));
		Vector3 eulerUpAngle = new Vector3(0, 0, 90);
		yield return StartCoroutine(SmoothRotation(eulerUpAngle));
		yield return StartCoroutine(SmoothMove(0.5f));
		isMoving = false;
	}

	private IEnumerator MoveDown() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(SmoothMove(1.5f));
		Vector3 eulerDownAngle = new Vector3(0, 0, -90);
		yield return StartCoroutine(SmoothRotation(eulerDownAngle));
		yield return StartCoroutine(SmoothMove(1.5f));
		isMoving = false;
	}

	private void Move() {
		RecalculateRay();

		if (!ProjectRay(rayDownDirection, 1.5f)) {
			return;
		}

		if (ProjectRay(rayFrontDirection, 1.5f)) {
			StartCoroutine(MoveUp());
		}

		else if (ProjectRay(rayFrontDownDirection)) {
			StartCoroutine(MoveFront());
		}

		else {
			StartCoroutine(MoveDown());
		}
	}
	
	#endregion
	
	#region Rotation
	private IEnumerator SmoothRotation(Vector3 angle) {
		float duration = 10;

		for (int i = 0; i < duration; i++) {
			transform.Rotate(angle / duration);
			yield return null;
		}
	}

	private IEnumerator RotateLeftSmooth() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(SmoothRotation(new Vector3(0, -90, 0)));
		isMoving = false;
	}

	private IEnumerator RotateRightSmooth() {
		if (isMoving) {
			yield break;
		}

		isMoving = true;
		yield return StartCoroutine(SmoothRotation(new Vector3(0, 90, 0)));
		isMoving = false;
	}

	private void RotateLeft() {
		StartCoroutine(RotateLeftSmooth());
	}

	private void RotateRight() {
		StartCoroutine(RotateRightSmooth());
	}
	
	#endregion

	#region Jump

	private IEnumerator SmoothJump(float offset) {
		if (isMoving) {
			yield break;
		}

		isMoving = true;

		Vector3 targetPos = transform.position + transform.up * offset;
		while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
			rollingBall.Roll(-step * 200);
			yield return null;
		}

		targetPos = transform.position - transform.up * offset;
		while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
			rollingBall.Roll(-step * 200);
			yield return null;
		}
		isMoving = false;
	}

	private IEnumerator SmoothMoveAndJump(float jumpOffset, float moveOffset) {
		if(isMoving)
			yield break;

		isMoving = true;
		RecalculateRay();
		bool flyDown = false;

		if (ProjectRay(rayFrontDirection, 1)) {
			moveOffset = 0;
		}
		else if(ProjectRay(rayFrontDirection, moveOffset)) {
			moveOffset = moveOffset / 2;
		}

		Vector3 targetPos = transform.position + (transform.up * jumpOffset) + (transform.right * moveOffset);
		GameObject block = getRayHit(targetPos, rayDownDirection, 10);
		float landingOffset = jumpOffset;

		if (moveOffset != 0) {
			if (block != null) {
				float distance = Vector3.Distance(targetPos, block.transform.position) - 1.5f;
				Mathf.Abs(distance);
				landingOffset = distance;
			}
			else {
				landingOffset = 10;
				flyDown = true;
			}

			while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
				float step = 2 * speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
				rollingBall.Roll(-step * 200);
				yield return null;
			}

			targetPos = transform.position - transform.up * landingOffset;
			while (Vector3.Distance(transform.position, targetPos) > 0.0001f) {
				float step = 2 * speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
				rollingBall.Roll(-step * 200);
				yield return null;
			}

			if (flyDown) {
				//gameOver
			}
			isMoving = false;
		}
	}

	private void Jump() {
		StartCoroutine(SmoothJump(2));
	}

	private void JumpAndMove(float offset) {
		StartCoroutine(SmoothMoveAndJump(offset, offset * 2));
	}

	#endregion
	
}