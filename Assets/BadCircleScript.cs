using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCircleScript : MonoBehaviour {

	float angle = 0;
	float speed = 0; 
	float radius = 0;

	private Transform _transform;
	private OrbitScript _currentOrbit;

	private const float FULL_CIRCLE = 2 * Mathf.PI / 3;

	void Awake () {
		_transform = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
		speed = FULL_CIRCLE;	
	}
	
	void Update() {
		if (_currentOrbit != null) {
			radius = _currentOrbit.radius;
			angle += speed * Time.deltaTime; 
			var posX = Mathf.Cos(angle) * radius;
			var posY = Mathf.Sin(angle) * radius;

			_transform.position = new Vector2 (posX, posY);
		}
	}

	public void SetOrbit(GameObject orbit) {
		if (orbit != null) {
			_currentOrbit = orbit.GetComponent<OrbitScript>();
			_currentOrbit.AddObject (gameObject);
		}
	}

	public GameObject GetCurrentOrbit() {
		return _currentOrbit.gameObject;
	}
}
