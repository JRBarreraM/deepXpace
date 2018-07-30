using UnityEngine;

public class RouteSimpleEnemy : MonoBehaviour {

	public static Transform[] points; //Arreglo de los puntos que conforman el camino

	void Awake() {
		points = new Transform[transform.childCount]; //Indicando que el tamaño del arreglo es la cantidad de hijos del objeto
		for (int i = 0; i < points.Length; i++) { //Ciclo for para asignar en cada posicion del arreglo un hijo del objeto, en este caso son posiciones
			points [i] = transform.GetChild (i); //Asignando a cada posicion del arreglo un hijo del objeto actual
		}
	}
}