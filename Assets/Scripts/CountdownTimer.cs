using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timeLeft = 60.0F;
	public Text timeLabel;

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLabel.text = string.Format("{0:00}:{1:00}:{2:00}",
			Mathf.Floor(timeLeft / 60),
			Mathf.Floor(timeLeft) % 60,
			Mathf.Floor(timeLeft*100) % 100);
	}
}
