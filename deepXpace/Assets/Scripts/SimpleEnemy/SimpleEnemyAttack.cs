using UnityEngine;

public class SimpleEnemyAttack : MonoBehaviour {

	/*Aun falta por definir (esto tambien puede hacerse en otros scripts):
		*Que posicion tomara el grupo de naves en su movimiento inicial y como se movera
		*Definir vida de la nave
		*Definir daño de la nave
		*Definir estados de la nave para animaciones (esto puede esperar mucho mas)
		*Definir la cantidad de disparos totales y su direccion
	*/
	[Header("Attributes")]
	[Tooltip("Tiempo que transcurre entre cada disparo")]
	public float shootRate; //Tiempo que pasa entre cada disparo de proyectil
	[Tooltip("Velocidad de la bala cuando el enemigo se mueve")]
	public float shootSpeedMoving; //Velocidad de la bala cuando el enemigo se mueve
	[Tooltip("Velocidad de la bala cuando el enemigo esta en espera")]
	public float shootSpeedWaiting; //Velocidad de la bala cuando el enemigo esta en espera
	[Tooltip("Separación entre cada una de las balas")]
	public float shootDiference; //Diferencia que existe entre el angulo de cada disparo

	[Header("Configuration and Resourses")]
	[Tooltip("Objeto que indica hacia donde disparar")]
	public GameObject target; //Almacena el objetivo actual al cual el enemigo apunta
	[Tooltip("Prefabricado de la bala")]
	public GameObject bulletPrefab; //bala prefabricada del enemigo simple

	private Vector3 initialPosition; //Posicion inicial del target
	private float initialDelay; //Almacena el retraso que debe ocurrir para volver a disparar

	void Start () {
		initialDelay = shootRate; //Guardamos el retraso para disparar
	}

	void Update () {

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Moving) { //Verificamos si el enemigo se esta moviendo
			//Ataque en movimiento
			target.transform.position = GameObject.Find ("Player").transform.position; //Indicamos que el objetivo es el objeto player
			if (shootRate <= 0f){ //Verificamos que podemos disparar
				ShootingInMovement(); //Llamamos al metodo encargado de ejecutar el disparo en movimiento

				shootRate = initialDelay; //Reiniciamos el retraso entre cada disparo
			}
			shootRate -= Time.deltaTime; //Restamos segundos para volver a disparar
		} 

		if (SimpleEnemyGroupMovement.state == SimpleEnemyGroupMovement.simpleEnemyStates.Waiting) { //Verificamos si el enemigo esta esperando
			//Ataque en espera
			target.transform.position = transform.position + Vector3.down * 3f; //Indicamos que el objetivo esta frente al enemigo
			if (shootRate <= 0f){ //Verificamos que podemos disparar
				ShootingInWaiting(); //Llamamos al metodo encargado de ejecutar el disparo en espera

				shootRate = initialDelay; //Reiniciamos el retraso entre cada disparo
			}
			shootRate -= Time.deltaTime; //Restamos segundos para volver a disparar
		} 
	}

	void ShootingInMovement() { //Tipo de disparo del enemigo simple cuando esta en movimiento
		//Instanciando cada una de las balas en una variable
		//GameObject bulletGO1 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		GameObject bulletGO2 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		//GameObject bulletGO3 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);

		//Accediendo al script de cada bala
		//SimpleEnemyBulletBehavior bullet1 = bulletGO1.GetComponent<SimpleEnemyBulletBehavior> ();
		SimpleEnemyBulletBehavior bullet2 = bulletGO2.GetComponent<SimpleEnemyBulletBehavior> ();
		//SimpleEnemyBulletBehavior bullet3 = bulletGO3.GetComponent<SimpleEnemyBulletBehavior> ();

		//Indicando a cada bala su objetivo, velocidad y su angulo de variacion
		//bullet1.SetAttributes (target.transform.position, shootSpeedMoving, shootDiference);
		bullet2.SetAttributes (target.transform.position, shootSpeedMoving, 0f);
		//bullet3.SetAttributes (target.transform.position, shootSpeedMoving, -shootDiference);
	}

	void ShootingInWaiting() { //Tipo de disparo del enemigo simple cuando esta en espera
		//Instanciando cada una de las balas en una variable
		//GameObject bulletGO1 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		GameObject bulletGO2 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		GameObject bulletGO3 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		GameObject bulletGO4 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);
		//GameObject bulletGO5 = (GameObject)Instantiate (bulletPrefab, transform.position, transform.rotation);

		//Accediendo al script de cada bala
		//SimpleEnemyBulletBehavior bullet1 = bulletGO1.GetComponent<SimpleEnemyBulletBehavior> ();
		SimpleEnemyBulletBehavior bullet2 = bulletGO2.GetComponent<SimpleEnemyBulletBehavior> ();
		SimpleEnemyBulletBehavior bullet3 = bulletGO3.GetComponent<SimpleEnemyBulletBehavior> ();
		SimpleEnemyBulletBehavior bullet4 = bulletGO4.GetComponent<SimpleEnemyBulletBehavior> ();
		//SimpleEnemyBulletBehavior bullet5 = bulletGO5.GetComponent<SimpleEnemyBulletBehavior> ();

		//Indicando a cada bala su objetivo, velocidad y su angulo de variacion
		//bullet1.SetAttributes (target.transform.position, shootSpeedWaiting, shootDiference * 2f);
		bullet2.SetAttributes (target.transform.position, shootSpeedWaiting, shootDiference);
		bullet3.SetAttributes (target.transform.position, shootSpeedWaiting, 0f);
		bullet4.SetAttributes (target.transform.position, shootSpeedWaiting, -shootDiference);
		//bullet5.SetAttributes (target.transform.position, shootSpeedWaiting, -shootDiference * 2f);
	}

}
