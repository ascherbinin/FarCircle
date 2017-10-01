using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              
	public PlayerCircleScript player;                      
	public int playerSpeed = 3;      
	public Text scoreText;

	private List<GameObject> _orbits = new List<GameObject> ();
	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.

	}



	//Update is called every frame.
	void Update()
	{

	}

	public void AddOrbit(GameObject orbit) {
		_orbits.Add (orbit);
		//Debug.Log ("ORBITS COUNT: " + _orbits.Count);

		if (player.GetCurrentOrbit() == null) {
			Debug.Log ("SET STARTED ORBIT: " + _orbits.Count);
			player.SetupPlayer (playerSpeed, orbit);
		}

	}

	public void RemoveOrbit(GameObject orbit) {
		_orbits.Remove (orbit);
	}

	public int GetOrbitsCount() {
		return _orbits.Count;
	}

	public GameObject GetNextOrbit(GameObject currentOrbit) {
		var index = _orbits.IndexOf (currentOrbit);
		if (index + 1 < _orbits.Count)
			return _orbits [index + 1];
		else
			return null;
	}

	public GameObject GetPreviosOrbit(GameObject currentOrbit) {
		var index = _orbits.IndexOf (currentOrbit);
		if (index - 1 > -1)
			return _orbits [index - 1];
		else
			return null;
	}

}
