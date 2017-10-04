using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleInputManager : MonoBehaviour {

//	private float _firstTapTime = 0f;
//	private float _timeBetweenTaps = 0.2f; // time between taps to be resolved in double tap
//	private bool _doubleTapInitialized;

	//private float _lastClickTime = 0.0F;
	//private bool _tap = false;

	//[Tooltip("Укажите разницу между кликами")]
	//public float CatchTime = 0.23F;

	void SingleTap()
	{
		//_doubleTapInitialized = false; // deinit double tap
		SingleClick();
	}

	void DoubleTap()
	{
		//_doubleTapInitialized = false;
		DoubleTap ();
	}

	void Update ()
	{
		
	}

	public void SingleClick () {
		//_tap = false;
		SimpleEventManager.TriggerEvent(SimpleEventType.Click);
	}

	public void DoubleClick() {
		//_tap = false;
		SimpleEventManager.TriggerEvent(SimpleEventType.DoubleClick);
	}
		
}
