using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

	public GameObject follow;

	void Start () {
		
	}

	void Update () {
		transform.position = new Vector3 (follow.transform.position.x,follow.transform.position.y,transform.position.z);
	}
}
