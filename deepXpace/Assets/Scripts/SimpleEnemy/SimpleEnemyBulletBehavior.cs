using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBulletBehavior : MonoBehaviour {

	private Vector3 target; //Almacena la posicion del objetivo a disparar
	private float speed; //Almacena la velocidad de cada bala
	private Vector3 targetModifier; //Almacena un vector que modifica la trayectoria de disparo
	private Vector3 updatingTarget; //Trayectoria final a seguir por la bala

	//Metodo publico que establece los valores necesarios para cada bala, el metodo es ejecutado desde SimpleEnemyAttack
	public void SetAttributes(Vector3 _target, float _speed, float _modifier) {
		//Asignamos cada valor segun los parametros sumistrados
		target = _target;
		speed = _speed;
		targetModifier = new Vector3(_modifier,0f,0f);
	}

	void Awake() {
		target = transform.position; //Indicamos que el objetivo por defecto es la misma bala
		speed = 0f; //Indicamos que la velocidad por defecto es cero
	}

	void Start() {
		updatingTarget = target - transform.position; //Buscamos la direccion de disparo
		updatingTarget = updatingTarget + targetModifier; //Modificamos la direccion de disparo. El valor del modificador puede ser el vector cero
	}

	void Update() {
		transform.Translate (updatingTarget.normalized * speed * Time.deltaTime, Space.World); //Indicamos a la bala que debe moverse en la direccion definida
	}

	//Metodo que verifica si un objeto esta fuera de camara, en este caso el objeto es cada bala
	void OnBecameInvisible() {
		Destroy (gameObject); //Si la camara sale de escena, estonces es destruida
	}
}