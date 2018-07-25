﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour {
	public float _speed;			// Valores ajustados a la escena piloto actual
	public float _layer;			//0
	public float mLeftBorder;		//-0.4f
	public float mRightBorder;		//0.4f
	public float mTopBorder;		//-0.9f
	public float mBottomBorder;		//0.9f
	public GameObject projectilePrefab;		//hay que agregar un projectilePrefab
	private bool mShooting;
	private float FireTimer = 0.2f;
	private float FireRate = 0.2f;
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
		FireTimer -= Time.deltaTime;
		if(Input.GetMouseButtonDown(0)) {
			mShooting = true;
		}

		if(Input.GetMouseButtonUp(0)) {
			mShooting = false;
		}

		if(FireTimer<=0 && mShooting) {
			Instantiate(projectilePrefab,mTransform.position,Quaternion.identity);
			FireTimer = FireRate;
			//audshoot.Play();
		}
	}

	void UpdateMovement() {
		Vector3 _target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
		_target.x = Mathf.Clamp(_target.x,mLeftBorder,mRightBorder);
		_target.y = Mathf.Clamp(_target.y,mTopBorder,mBottomBorder);
		_target.z = _layer;
		transform.position = Vector3.MoveTowards(transform.position,_target,_speed*Time.deltaTime);
	}
		
}