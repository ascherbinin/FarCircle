using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInputManager : MonoBehaviour {

	private float _lastClickTime = 0.0F;
	private bool _tap = false;

	[Tooltip("Укажите разницу между кликами")]
	public float CatchTime = 0.23F;

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

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Invoke("SingleClick", CatchTime);

			if (!_tap) {
				_tap = true;
				_lastClickTime = Time.time;
			}
			else if (Time.time - _lastClickTime < CatchTime) {
				CancelInvoke("SingleClick");
				DoubleClick();
			}

//			if(Time.time < _lastClickTime + catchTime)
//			{
//				//double click
//				//print("Double click");
//				SimpleEventManager.TriggerEvent(EventType.DoubleClick);
//				_tap = false;
//				return;
//			}
//			_tap = true;
//			_lastClickTime = Time.time;
//		}
//		if (_tap == true && Time.time > _lastClickTime + catchTime) {
//			_tap = false;

		}


		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				switch (Input.GetTouch(i).tapCount) {
				case 1: 
					SimpleEventManager.TriggerEvent(EventType.Click);
					break;
				case 2:
					SimpleEventManager.TriggerEvent(EventType.DoubleClick);
					break;
				default:
				break;
				}
			}
		}

		#endif
	}

	void SingleClick () {
		_tap = false;
		SimpleEventManager.TriggerEvent(EventType.Click);
	}

	void DoubleClick() {
		_tap = false;
		SimpleEventManager.TriggerEvent(EventType.DoubleClick);
	}
		
}
