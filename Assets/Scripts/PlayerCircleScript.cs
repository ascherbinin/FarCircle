﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircleScript : MonoBehaviour {




	float angle = 0;
	float speed = 0; 
	float radius = 0;

	private GameObject _currentOrbit;
	private Transform _transform;
	private float _circleSpeed;

	private const float FULL_CIRCLE = 2 * Mathf.PI;

	public void SetupPlayer(float circleSpeed, GameObject startOrbit) {
		_circleSpeed = circleSpeed;
		_currentOrbit = startOrbit;
		speed = FULL_CIRCLE / 5 ;/// _circleSpeed; 
	}

	void Awake () {
		_transform = GetComponent<Transform> ();
	}

	void OnEnable ()
	{
		SimpleEventManager.StartListening (EventType.Click, MoveToCenter);
		SimpleEventManager.StartListening (EventType.DoubleClick, MoveFromCenter);
		//SimpleEventManager.StartListening (EventType.ToCenterSwipe, MoveToCenter);
		//SimpleEventManager.StartListening (EventType.FromCenterSwipe, MoveFromCenter);
	}

	void OnDisable ()
	{
		SimpleEventManager.StopListening (EventType.Click, MoveToCenter);
		SimpleEventManager.StopListening (EventType.DoubleClick, MoveFromCenter);
		//SimpleEventManager.StopListening (EventType.ToCenterSwipe, MoveToCenter);
		//SimpleEventManager.StopListening (EventType.FromCenterSwipe, MoveFromCenter);
	}

	void MoveToCenter() {
		//_transform.position = new Vector2 (transform.position.x + 0.3F, transform.position.y);
		ChangeCurrentOrbit(GameManager.instance.GetPreviosOrbit(_currentOrbit));
		//print ("Move to center");
	}

	void MoveFromCenter() {
		//_transform.position = new Vector2 (transform.position.x - 0.3F, transform.position.y);
		ChangeCurrentOrbit(GameManager.instance.GetNextOrbit(_currentOrbit));
		//print("Move from center");
	}

	void Update() {

		Debug.Log (speed);
		radius = _currentOrbit.GetComponent<OrbitScript>().radius;
		angle += speed * Time.deltaTime; 
		var posX = Mathf.Cos(angle) * radius;
		var posY = Mathf.Sin(angle) * radius;

		_transform.position = new Vector2 (posX, posY);
	}

	public void ChangeCurrentOrbit(GameObject orbit) {
		if (orbit != null) {
			//Debug.Log (orbit.name);
			_currentOrbit = orbit;
			Debug.Log (_circleSpeed);
		}
	}

	public GameObject GetCurrentOrbit() {
		return _currentOrbit;
	}
}
