using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject spawnObject;
	public float timeToSpawn = 2F;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0F, timeToSpawn);
	}
	
	// Update is called once per frame
	void Update () {
//		_lastTimeSpawn += Time.deltaTime;
//		if (_lastTimeSpawn > TimeToSpawn) {
//			Spawn ();
//		}
	}

	void Spawn() {
//		_lastTimeSpawn = 0.0F;
		var orbit = Instantiate (spawnObject, gameObject.transform.position, Quaternion.identity);
		orbit.name = string.Format ("Orbit [{0}]", GameManager.instance.GetOrbitsCount () + 1);
		GameManager.instance.AddOrbit (orbit);
	}
}
