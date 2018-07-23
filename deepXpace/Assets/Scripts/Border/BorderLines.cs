using UnityEngine;

public class BorderLines : MonoBehaviour {

	//Puntos frontera delimitados por la camara principal, MainCamera
	Vector3 point0 = new Vector3(-1f,1f,0f);
	Vector3 point1 = new Vector3(1f,1f,0f);
	Vector3 point2 = new Vector3(0f,1f,0f);
	Vector3 point3 = new Vector3(-1f,0f,0f);
	Vector3 point4 = new Vector3(-1f,-1f,0f);
	//Vector3 point5 = new Vector3(0f,-1f,0f);
	Vector3 point6 = new Vector3(1f,-1f,0f);
	Vector3 point7 = new Vector3(1f,0f,0f);
	Vector3 point8 = new Vector3(0f,0f,0f);

	void OnDrawGizmosSelected() { //Metodo que dibuja objetos para uso de desarrollo, no son visualizados en el producto final
		Gizmos.color = Color.cyan; //Determinamos el color de las lineas
		//Dibujando lineas separadoras
		Gizmos.DrawLine (point0, point1);
		Gizmos.DrawLine (point3, point7);
		Gizmos.DrawLine (point4, point6);
		Gizmos.DrawLine (point2, point8);
		Gizmos.DrawLine (point0, point4);
		Gizmos.DrawLine (point1, point6);
	}
}
