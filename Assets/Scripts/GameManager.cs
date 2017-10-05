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

	private int _score;
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
		if ((int)Time.time % 10 == 0) {
			AddScore(Random.Range(10,50));
		}
	}

	public void AddOrbit(GameObject orbit) {
		_orbits.Add (orbit);
		if (player.GetCurrentOrbit() == null) {
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

	public void AddScore(int score) {
		_score += score;
		scoreText.text =  _score.ToString ("0000000000");
	}

}
