﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public enum EventType {
	Click,
	DoubleClick,
	ToCenterSwipe,
	FromCenterSwipe
};

public class SimpleEventManager : MonoBehaviour {

	private Dictionary <EventType, UnityEvent> eventDictionary;

	private static SimpleEventManager eventManager;

	public static SimpleEventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (SimpleEventManager)) as SimpleEventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<EventType, UnityEvent>();
		}
	}

	public static void StartListening (EventType eventType, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventType, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventType, thisEvent);
		}
	}

	public static void StopListening (EventType eventType, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventType, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (EventType eventType)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventType, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}
}