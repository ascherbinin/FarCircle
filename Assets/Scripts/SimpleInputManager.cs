using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleInputManager : MonoBehaviour {

	private Vector2 fp;   //First touch position
	private Vector2 lp;   //Last touch position
	private float dragDistance;  //minimum distance for a swipe to be registered

	void Start()
	{
		dragDistance = Screen.height * 5 / 100; //dragDistance is 5% height of the screen
	}

	void Update()
	{
		#if UNITY_EDITOR || (!UNITY_IPHONE && !UNITY_ANDROID)
		if (Input.GetMouseButtonDown(0)) {
			fp = Input.mousePosition;
			lp = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0)) {
			lp = Input.mousePosition;

			Debug.Log(fp);
			Debug.Log(lp);

			if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
			{
				Debug.Log("Swipe");
				SimpleEventManager.TriggerEvent(SimpleEventType.Swipe);
			}
			else
			{   
				Debug.Log("Tap");
				SimpleEventManager.TriggerEvent(SimpleEventType.Tap);

			}
		}

		#else
		// Touches and Acceleration from the iOS device

		if (Input.touchCount == 1) // user is touching the screen with a single touch
		{
			Touch touch = Input.GetTouch(0); // get the touch
			if (touch.phase == TouchPhase.Began) //check for the first touch
			{
				fp = touch.position;
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
			{
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
			{
				lp = touch.position;  //last touch position. Ommitted if you use list

				//Check if drag distance is greater than 20% of the screen height
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{//It's a drag
					//check if the drag is vertical or horizontal
					Debug.Log("Swipe");
				}
				else
				{   //It's a tap as the drag distance is less than 20% of the screen height
					Debug.Log("Tap");
				}
			}
		}
		#endif
	}

}
