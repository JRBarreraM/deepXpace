using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour {

	public float mLeftBorder;
	public float mRightBorder;
	public float mTopBorder;
	public float mBottomBorder;

	void Awake () {
		mTransform = transform;
	}

	void Start () {
		mLeftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.05f,0,0)).x;
		mRightBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.95f,0,0)).x;
		mTopBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0.05f,0)).y;
		mBottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0.095f,0)).y;

		Cursor.visible = false;
	}
	
	void Update () {
		UpdateMovement();
	}

	void UpdateMovement() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlano));
		pos.x = Mathf.Clamp(pos.x,mLeftBorder,mRightBorder);
		pos.y = Mathf.Clamp(pos.y,mTopBorder,mBottomBorder);
		pos.z = 0;
		mTransform.position = pos
	}

}
