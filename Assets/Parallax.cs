using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{
	public float speed = 0.5f;
	public Vector2 endlesPoint;
	public Vector2 startPoint;
	private Rigidbody2D _rb2d;

	void Start() {

		_rb2d = GetComponent<Rigidbody2D> ();

		_rb2d.velocity = new Vector2 (-speed, speed);
	}

	void Update ()
	{
		if (transform.position.x < endlesPoint.x || transform.position.y > endlesPoint.y)
		{
			transform.position = new Vector2(startPoint.x - 0.1F, startPoint.y + 0.1F);
		}
	}
}
