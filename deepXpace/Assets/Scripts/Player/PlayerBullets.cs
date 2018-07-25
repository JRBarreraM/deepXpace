using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {
	Transform mTransform;
	public float _speed;
	private float mBorder;
	// Use this for initialization
	void Awake() {
		mTransform = transform;
		mBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0, 1, 0)).y;
	}
	
	// Update is called once per frame
	void Update () {
		mTransform.Translate(0, _speed * Time.deltaTime, 0);
		if (mTransform.position.y == mBorder) {
			Destroy(gameObject);
		}
			
	}
}
