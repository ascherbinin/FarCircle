using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircleScript : MonoBehaviour {

	float angle = 0;
	float speed = 0; 
	float radius = 0;

	private OrbitScript _currentOrbit;
	private Transform _transform;
	private float _circleSpeed;

	private const float FULL_CIRCLE = 2 * Mathf.PI;

	public void SetupPlayer(float circleSpeed, GameObject startOrbit) {
		_circleSpeed = circleSpeed;
		_currentOrbit = startOrbit.GetComponent<OrbitScript> ();
		speed = FULL_CIRCLE / _circleSpeed ;/// _circleSpeed; 
	}

	void Awake () {
		_transform = GetComponent<Transform> ();
	}

	void OnEnable ()
	{
//		SimpleEventManager.StartListening (SimpleEventType.Tap, MoveToCenter);
//		SimpleEventManager.StartListening (SimpleEventType.Swipe, MoveFromCenter);
		SimpleEventManager.StartListening (SimpleEventType.RightSideTap, MoveToCenter);
		SimpleEventManager.StartListening (SimpleEventType.LeftSideTap, MoveFromCenter);
	}

	void OnDisable ()
	{
//		SimpleEventManager.StopListening (SimpleEventType.Tap, MoveToCenter);
//		SimpleEventManager.StopListening (SimpleEventType.Swipe, MoveFromCenter);
		SimpleEventManager.StopListening (SimpleEventType.RightSideTap, MoveToCenter);
		SimpleEventManager.StopListening (SimpleEventType.LeftSideTap, MoveFromCenter);
	}

	void MoveToCenter() {
		ChangeCurrentOrbit(GameManager.instance.GetNextOrbit(_currentOrbit.gameObject));
	}

	void MoveFromCenter() {
		ChangeCurrentOrbit(GameManager.instance.GetPreviosOrbit(_currentOrbit.gameObject));
	}

	void Update() {
		radius = _currentOrbit.radius;
		angle += speed * Time.deltaTime; 
		var posX = Mathf.Cos(angle) * radius;
		var posY = Mathf.Sin(angle) * radius;

		_transform.position = new Vector2 (posX, posY);
	}

	public void ChangeCurrentOrbit(GameObject orbit) {
		if (orbit != null) {
			//speed = FULL_CIRCLE / ( _circleSpeed * radius ) ;
			_currentOrbit.RemoveObject(gameObject);
			_currentOrbit = orbit.GetComponent<OrbitScript>();;
			_currentOrbit.AddObject(gameObject);
		}
	}

	public GameObject GetCurrentOrbit() {
		return _currentOrbit != null ? _currentOrbit.gameObject : null;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bad") {
			print ("TOUCH PLAYER");
		}
	}
}
