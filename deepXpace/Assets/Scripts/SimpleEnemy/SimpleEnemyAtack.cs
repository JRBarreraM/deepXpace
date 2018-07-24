using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAtack : MonoBehaviour {

	public GameObject target; //Almacena el objetivo actual al cual el enemigo apunta
	public float shootSpeed; //Velocidad del proyectil
	public float shootRate; //Tiempo que pasa entre cada disparo de proyectil

	private Vector3 initialPosition; //Posicion inicial del target

	void Start () {
		initialPosition = target.transform.position; //Guardamos la posicion inicial para usarla mas tarde
	}

	void Update () {
		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Moving) { //Verificamos si el enemigo se esta moviendo
			Debug.Log ("Ataque Uno"); //Usamos el tipo de ataque en movimiento
		} 

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Waiting) { //Verificamos si el enemigo esta esperando
			Debug.Log ("Ataque Dos"); //Usamos el tipo de ataque en espera
		} 
	}
}
