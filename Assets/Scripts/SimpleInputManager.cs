using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleInputManager : MonoBehaviour {

	private float _firstTapTime = 0f;
	private float _timeBetweenTaps = 0.2f; // time between taps to be resolved in double tap
	private bool _doubleTapInitialized;

	//private float _lastClickTime = 0.0F;
	//private bool _tap = false;

	//[Tooltip("Укажите разницу между кликами")]
	//public float CatchTime = 0.23F;

	public void OnPointerDown(PointerEventData eventData)
	{
		// invoke single tap after max time between taps
		Invoke("SingleTap", _timeBetweenTaps);

		if (!_doubleTapInitialized)
		{
			// init double tapping
			_doubleTapInitialized = true;
			_firstTapTime = Time.time;
		}
		else if (Time.time - _firstTapTime < _timeBetweenTaps)
		{
			// here we have tapped second time before "single tap" has been invoked
			CancelInvoke("SingleTap"); // cancel "single tap" invoking
			DoubleTap();
		}
	}

	void SingleTap()
	{
		_doubleTapInitialized = false; // deinit double tap
		SingleClick();
	}

	void DoubleTap()
	{
		_doubleTapInitialized = false;
		DoubleTap ();
	}

	void Update ()
	{
		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		//      Swipe section at future
		//		if (Input.GetMouseButtonDown (0)) {
		//			firstPressPos = Input.mousePosition;
		//		}
		//		if (Input.GetMouseButtonUp (0)) {
		//			var secondPressPos = (Vector2)Input.mousePosition;
		//			currentSwipe = secondPressPos - firstPressPos;
		//			if (currentSwipe != Vector2.zero) {
		//				//var normalizedSwipe = currentSwipe.normalized;
		//				var deltaFirst = _screenCenter - firstPressPos;
		//				var deltaSecond = _screenCenter - secondPressPos;
		//				Debug.Log(deltaFirst + "---" + deltaSecond);
		//				if (deltaFirst.x > deltaSecond.x && deltaFirst.y < deltaSecond.y) {
		//					Debug.Log("To Center");
		//				}
		//				else {
		//					Debug.Log("From Center");
		//				}
		////				if (firstPressPos > secondPressPos) {
		////					Debug.Log("First press" + firstPressPos);
		////				}
		////				if (normalizedSwipe.x > 0 || normalizedSwipe.y > 0) {
		////					SimpleEventManager.TriggerEvent(EventType.ToCenterSwipe);
		////				}
		////				else {
		////					SimpleEventManager.TriggerEvent(EventType.FromCenterSwipe);
		////				}
		//			}
		//		}

//		if(Input.GetKeyDown(KeyCode.Mouse0))
//		{
//			Invoke("SingleClick", CatchTime);
//
//			if (!_tap) {
//				_tap = true;
//				_lastClickTime = Time.time;
//			}
//			else if (Time.time - _lastClickTime < CatchTime) {
//				CancelInvoke("SingleClick");
//				DoubleClick();
//			}
//		}




		}
		}

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				switch (Input.GetTouch(i).tapCount) {
				case 1: 
					SimpleEventManager.TriggerEvent(SimpleEventType.Click);
					break;
				case 2:
					SimpleEventManager.TriggerEvent(SimpleEventType.DoubleClick);
					break;
				default:
				break;
				}
			}
//		}

		#endif
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
