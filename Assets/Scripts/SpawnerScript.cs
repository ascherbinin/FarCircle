using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject spawnOrbitObject;
	public GameObject badCircleObject;
	public float timeToSpawn = 2F;

	private Vector2 _centerPosition = new Vector2(0,0);
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

		var orbit = Instantiate (spawnOrbitObject, gameObject.transform.position, Quaternion.identity);
		orbit.name = string.Format ("Orbit [{0}]", GameManager.instance.GetOrbitsCount () + 1);
		GameManager.instance.AddOrbit (orbit);
		if (Random.Range (0, 10) > 2) {
			var bCircle = Instantiate (badCircleObject, _centerPosition, Quaternion.identity);
			bCircle.GetComponent<BadCircleScript> ().SetOrbit (orbit);
		}
	}
}
