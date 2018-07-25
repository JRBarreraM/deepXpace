using UnityEngine;

public class SimpleEnemyBulletBehavior : MonoBehaviour {

	private Transform target;
	private float speed;

	void SetTarget(Vector3 _target) {
		target.position = _target;
	}

	void SetSpeed(float _speed) {
		speed = _speed;
	}

	void Start () {
		transform.Translate (target.position * speed * Time.deltaTime,Space.World);
	}
}
