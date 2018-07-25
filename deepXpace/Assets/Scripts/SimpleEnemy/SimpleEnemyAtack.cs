using UnityEngine;

public class SimpleEnemyAtack : MonoBehaviour {

	public GameObject target; //Almacena el objetivo actual al cual el enemigo apunta
	public float shootSpeed; //Velocidad del proyectil
	public float shootRate; //Tiempo que pasa entre cada disparo de proyectil

	private Vector3 initialPosition; //Posicion inicial del target
	private Vector3 playerPosition; //Posicion actual del objeto player
	private Vector3 direction; //Direccion de disparo

	void Start () {
		initialPosition = target.transform.position; //Guardamos la posicion inicial para usarla mas tarde
	}

	void Update () {
		playerPosition = GameObject.Find ("Player").transform.position;
		direction = target.transform.position - transform.position;

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Moving) { //Verificamos si el enemigo se esta moviendo
			MoovingAtack();
		} 

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Waiting) { //Verificamos si el enemigo esta esperando
			WaitingAtack();
		} 
	}

	void MoovingAtack() {
		target.transform.position = transform.position + initialPosition;
	}

	void WaitingAtack() {
		target.transform.position = playerPosition;
	}

	void Shoot() {
		
	}
}
