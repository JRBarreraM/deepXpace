using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour {

	[Header("Attributes")]
	[Tooltip("Tiempo que ocurre entra cada aparición de enemigos")]
	public float timeBetweenGroups; //Tiempo entre aparicion de cada grupo
	[Tooltip("Cantidad maxima de enemigos de un tipo")]
	public float maxActualEnemyCount;

	[Header("Configuration and Resourses")]
	[Tooltip("Prefabricado del enemigo actual que es instanciado")]
	public GameObject actualEnemy; //Capturando el prefab del grupo de enemigos simples
	[Tooltip("Tag del enemigo actual que es instanciado")]
	public string enemyTag; //Indicando el tag del enemigo

	private float timeCount; //Tiempo transcurrido calculado en funcion del Time.deltaTime
	private int totalActualEnemy; //Indica la cantidad de enemigos, del tag indicado, actuales en escena

	void Start () {
		timeCount = timeBetweenGroups; //Inicializamos el contador de tiempo en el tiempo de aparicion
	}

	void Update () {
		totalActualEnemy = GameObject.FindGameObjectsWithTag (enemyTag).Length; //Asignamos en cada iteracion la cantidad de enemigos actuales

		if (totalActualEnemy < maxActualEnemyCount) { //Verificamos que aun podemos seguir instanciando enemigos
			if (timeCount <= 0f) { //Verificamos que podemos instanciar el siguiente enemigo, esto se hace viendo si ya pasaron tantos segundos
				Spawn (); //Llamamos al metodo Spawn para instanciar el enemigo correspondiente
				timeCount = timeBetweenGroups; //Resetamos el contador de tiempo
			}

			timeCount -= Time.deltaTime; //Descontamos un segundo en el contador de tiempo
		}
	}

	void Spawn() { //Metodo que se encarga de instanciar un tipo de enemigo especifico
		Instantiate (actualEnemy, transform.position, transform.rotation);
	}
}
