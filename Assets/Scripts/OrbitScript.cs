using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour {

	private Transform _transform;
	private CircleCollider2D _collider;

	public float speed = 1.0F;
	public float radius = 0;

	private int _index = 0;

	void Awake () {
		_transform = GetComponent<Transform> ();
		_collider = GetComponent<CircleCollider2D> ();
	}

	void Start() {
		radius = _collider.radius * _transform.localScale.x;
	}
		
	void Update () {
		_transform.localScale += Vector3.one * speed * Time.deltaTime;
		radius = _collider.radius * _transform.localScale.x;
//		Debug.Log (radius);
		if (_transform.localScale.x > 20) {
			GameManager.instance.RemoveOrbit (gameObject);
			Destroy (gameObject);
		}
	}

	public void SetupIndex(int index) {
		_index = index;
	}

	public int GetIndex() {
		return _index;
	}
}
