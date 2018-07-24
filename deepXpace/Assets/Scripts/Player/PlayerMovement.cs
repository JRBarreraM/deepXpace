using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float speedX;
	float speedY;
	float left;
	float right;
	float up;
	float down;

	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			left = -1;
		} else {
			left = 0;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			right = 1;
		} else {
			right = 0;
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			down = -1;
		} else {
			down = 0;
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			up = 1;
		} else {
			up = 0;
		}

		speedX = (left + right) * 3f * Time.deltaTime;
		speedY = (up + down) * 3f * Time.deltaTime;

		transform.position = new Vector3 (speedX + transform.position.x, speedY + transform.position.y, transform.position.z);
	}
}
