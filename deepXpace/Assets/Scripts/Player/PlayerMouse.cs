using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour {
	public float _speed;			// Valores ajustados a la escena piloto actual
	public float _layer;			//0
	public float mLeftBorder;		//-0.4f
	public float mRightBorder;		//0.4f
	public float mTopBorder;		//-0.9f
	public float mBottomBorder;		//0.9f
	private Transform mTransform;

	void Awake () {
		mTransform = transform;
	}

	void Start () { //incializamos al jugador al fondo y en el centro
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(0,mBottomBorder,Camera.main.nearClipPlane));
		mTransform.position = pos;
		Cursor.visible = false;
	}
	
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement() {
		Vector3 _target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
		_target.x = Mathf.Clamp(_target.x,mLeftBorder,mRightBorder);
		_target.y = Mathf.Clamp(_target.y,mTopBorder,mBottomBorder);
		_target.z = _layer;
		transform.position = Vector3.MoveTowards(transform.position,_target,_speed*Time.deltaTime);
	}
		
}