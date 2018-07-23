using UnityEngine;
using System.Collections;

public class SimpleEnemyGroupMovement : MonoBehaviour {

	public float speed = 5f; //Determina la velocidad del enemigo
	public float delay = 3f; //Determina el tiempo que pasara el enemigo antes de ir al siguiente punto

	private Transform target; //Punto actual a seguir
	private int pointIndex = 0; //Indice del arreglo de puntos a seguir
	private float timeCount; //Contador para indicar cuando termina el tiempo de espera antes de seguir al punto siguiente

	void Start () {
		target = RouteSimpleEnemy.points[0]; //Indicamos que el objetivo a seguir es el primer punto de la secuencia
		timeCount = delay; //Inicializamos el contador de tiempo en el tiempo de retardo
	}

	void Update () {
		Vector3 direction = target.position - transform.position; //Guardamos la direccion entre el target y el enemigo

		if (Vector3.Distance (target.position, transform.position) <= 0.01f) { //Verificamos si la distancia entre target y enemigo es menor a 0.01
			if (timeCount <= 0){ //Verificamos si el contador de tiempo es menor igual a cero
				GetNextPoint (); //Llamamos a GetNextPoint para indicar que ya alcanzamos el punto actual y queremos seguir el punto siguiente
				timeCount = delay; //Reiniciamos el contador al tiempo de retardo
			}

			timeCount -= Time.deltaTime; //Restamos al contador el equivalente en segundos por frame

		} else { //Si la distancia aun no es lo suficientemente pequeña, entonces
			transform.Translate (direction.normalized * speed * Time.deltaTime, Space.World); //Trasladamos el enemigo hasta la posicion del target
		}
	}

	void GetNextPoint() { //Metodo que cambia el contenido de target, es decir, los puntos a seguir
		if (pointIndex == RouteSimpleEnemy.points.Length - 1) { //Verificamos que hemos llegado al final del arreglo de puntos
			pointIndex = 0; //Reiniciamos el indice del arreglo
		} else { //Si aun no hemos llegado al final del arreglo
			pointIndex++; //Incrementamos en uno el indice del arreglo
		}

		target = RouteSimpleEnemy.points [pointIndex]; //A target le asignamos uno nuevo punto, en este caso, el siguiente en el arreglo
	}
}
