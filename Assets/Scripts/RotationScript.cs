using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

	public float rotationSpeed;
	void Update () {
		transform.Rotate (0, 0, Time.deltaTime * rotationSpeed);	
	}
}
