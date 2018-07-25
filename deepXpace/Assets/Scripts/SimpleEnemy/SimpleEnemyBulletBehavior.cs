using UnityEngine;

public class SimpleEnemyBulletBehavior : MonoBehaviour {

	private Transform target;
	private float speed;

	public void SetAttributes(Vector3 _target, float _speed) {
		target.position = _target;
		speed = _speed;
	}

	void Awake() {
		target = transform;
		speed = 0f;
	}

	void Start () {
		transform.Translate (target.position * speed * Time.deltaTime,Space.World);
	}
}
