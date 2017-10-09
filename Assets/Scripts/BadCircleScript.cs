using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCircleScript : MonoBehaviour {

	float angle = 0;
	float speed = 0; 
	float radius = 0;

	private Transform _transform;
	private SpriteRenderer _renderer;
	private OrbitScript _currentOrbit;

	private const float FULL_CIRCLE = 2 * Mathf.PI / 3;

	public Transform _exitVector;

	void Awake () {
		_transform = GetComponent<Transform> ();
		_renderer = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		speed = FULL_CIRCLE + Random.Range(0.0F, 1.0F);
		angle = Random.Range (45, 90);
	}
	
	void Update() {
		if (_currentOrbit != null) {
			radius = _currentOrbit.radius;
			angle += speed * Time.deltaTime; 
			var posX = Mathf.Cos(angle) * radius;
			var posY = Mathf.Sin(angle) * radius;

			_transform.position = new Vector2 (posX, posY);
			_exitVector.LookAt (_currentOrbit.transform);
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

	public void DetachOrbitAndFly() {
		_currentOrbit = null;
		speed = 0;
		var rb = gameObject.AddComponent<Rigidbody2D> ();
		_renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.g, 0.5F);
		//_transform.localScale = new Vector2 (_transform.localScale.x - 0.03F, _transform.localScale.y - 0.03F);
		rb.mass = 5;
		rb.AddForce ((_exitVector.transform.rotation.y > 0 ? - _exitVector.up :   _exitVector.up) * 50, ForceMode2D.Impulse);
		rb.gameObject.layer = 11;
	}
}
