﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour {

	public GameObject actualEnemy; //Capturando el prefab del grupo de enemigos simples
	public float timeBetweenGroups = 6f; //Tiempo entre aparicion de cada grupo
	public string enemyTag; //Indicando el tag del enemigo
	public float maxActualEnemyCount;

	private float timeCount; //Tiempo transcurrido calculado en funcion del Time.deltaTime
	private int totalActualEnemy; //Indica la cantidad de enemigos, del tag indicado, actuales en escena

	void Start () {
		timeCount = timeBetweenGroups; //Inicializamos el contador de tiempo en el tiempo de aparicion
	}

	void Update () {
		totalActualEnemy = GameObject.FindGameObjectsWithTag (enemyTag).Length; //Asignamos en cada iteracion la cantidad de enemigos actuales

		if (totalActualEnemy < maxActualEnemyCount) {
			if (timeCount <= 0f) {
				Spawn ();
				timeCount = timeBetweenGroups;
			}

			timeCount -= Time.deltaTime;
		}
	}

	void Spawn() {
		Instantiate (actualEnemy, transform.position, transform.rotation);
	}
}