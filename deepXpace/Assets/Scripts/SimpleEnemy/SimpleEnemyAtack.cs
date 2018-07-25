using UnityEngine;

public class SimpleEnemyAtack : MonoBehaviour {

	public GameObject target; //Almacena el objetivo actual al cual el enemigo apunta
	public GameObject bulletPrefab;
	public float shootRate; //Tiempo que pasa entre cada disparo de proyectil
	public float shootSpeedMoving;
	public float shootSpeedWaiting;

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
			//Ataque en movimiento
		} 

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Waiting) { //Verificamos si el enemigo esta esperando
			//Ataque en espera
		} 
	}

	void ShootingInMovement() {
		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		SimpleEnemyBulletBehavior bullet = bulletGO.GetComponent<SimpleEnemyBulletBehavior> ();

		bullet.SetAttributes (direction.normalized, shootSpeedMoving);
	}
}
