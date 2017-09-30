using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {
	
	private Transform _transform;
	private CircleCollider2D _collider;
	public float radius { get; set; }

	void Awake () {
		_transform = GetComponent<Transform> ();
		_collider = GetComponent<CircleCollider2D> ();
	}

	void Start() {
		radius = _collider.radius * _transform.localScale.x;
	}


}
