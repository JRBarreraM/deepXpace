using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenario : MonoBehaviour {


	void OnDrawGizmosSelected() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (Vector3.zero, 16f);
	}
}
