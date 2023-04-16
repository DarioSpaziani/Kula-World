using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine : MonoBehaviour {
	public bool hasTriggered;
	private Vector3 startPosition, destination;
	public float speed = 0.01f;

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
			Manager.Instance.InitDie();
		}
	}
}
