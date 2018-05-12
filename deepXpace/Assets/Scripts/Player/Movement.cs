using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		float fixedSpeed = speed * Time.deltaTime;
		rb.velocity = new Vector2 (Input.GetAxis("Horizontal") * fixedSpeed ,Input.GetAxis("Vertical") * fixedSpeed);
	}
}
