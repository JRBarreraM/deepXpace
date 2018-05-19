using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	//Variables publicas
	public float vHMax; //Máxima velocidad horizontal
	public float vHMin; //Mínima velocidad horizontal
	public float vVMax;	//Máxima velocidad vertical
	public float vVMin; //Mínima velocidad vertical
	public float aH; //Aceleración horizontal actual
	public float aV; //Aceleración vertical actual
	public float fH; //Fricción horizontal actual
	public float fV; //Fricción vertical actual
	public Vector3 initialPosition; //Posición inicial de la nave

	//Variables privadas
	private float avanceX; //Dirección del movimiento horizontal, permite los valores -1, 0, 1
	private float avanceY; //Dirección del movimiento vertical, permite los valores -1, 0, 1
	private float vH; //Velocidad horizontal actual
	private float vV; //Velocidad vertical actual

	void Start () {
		//Almacena la posición inicial de la nave
		transform.position = initialPosition;
	}

	void FixedUpdate () {
		//Asignación de la dirección del movimiento
		avanceX = Mathf.Round(Input.GetAxis ("LH"));
		avanceY = Mathf.Round(Input.GetAxis ("LV"));

		//Rotación de la nave
		float rotacion = 0f; //Orientación de la nave
		rotacion += 5 * -Input.GetAxis ("TRIGGER");
		transform.Rotate (0f,0f,rotacion);

		//Aceleración y frenado en el movimiento horizontal
		if (avanceX != 0) {
			if (avanceX > 0) {
				vH = Mathf.Min (vH + aH, vHMax);
			} else {
				vH = Mathf.Max (vH - aH, -vHMax);
			}
		} else {
			if (vH > 0) {
				vH = Mathf.Max (vH - fH, vHMin);
			} else {
				vH = Mathf.Min (vH + fH, vHMin);
			}
		}

		//Aceleración y frenado en el movimiento vertical
		if (avanceY != 0) {
			if (avanceY > 0) {
				vV = Mathf.Min (vV + aV, vVMax);
			} else {
				vV = Mathf.Max (vV - aV, -vVMax);
			}
		} else {
			if (vV > 0) {
				vV = Mathf.Max (vV - fV, vVMin);
			} else {
				vV = Mathf.Min (vV + fV, vVMin);
			}
		}

		//Movimiento definitivo de la nave
		transform.position = new Vector3 (transform.position.x + vH, transform.position.y + vV, transform.position.z);
	}

}
