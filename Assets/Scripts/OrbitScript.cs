using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour {

	private Transform _transform;
	private CircleCollider2D _collider;
	private ParticleSystem _particle;
	private SpriteRenderer _renderer;
	private GameObject _border;
	public float speed = 1.0F;
	public float radius = 0;

	private int _index = 0;
	private float _fadeDuration;
	private Color _spriteColor;
	public bool _isFading = false;
	public float _startFadeTime;

	void Awake () {
		_border = GameObject.FindGameObjectWithTag ("Border");
		_transform = GetComponent<Transform> ();
		_collider = GetComponent<CircleCollider2D> ();
		_particle = GetComponent<ParticleSystem> ();
		_renderer = GetComponent<SpriteRenderer> ();
	}

	void Start() {
		radius = _collider.radius * _transform.localScale.x;
		_fadeDuration = _particle.main.duration / 2.5F;
		_spriteColor = _renderer.color;
	}

	void Update () {
		if (radius > _border.GetComponent<BorderScript> ().radius) {
			if (!_isFading)
				_startFadeTime = Time.time;
			_isFading = true;
		}

		if (_isFading) {
			GameManager.instance.RemoveOrbit (gameObject);
			float t = (Time.time - _startFadeTime) / _fadeDuration;
			float fade = Mathf.SmoothStep (1, 0, t);
			_spriteColor.a = fade;
			_renderer.color = _spriteColor;
			StartCoroutine (DestroyObject ());
		} else {
			_transform.localScale += Vector3.one * speed * Time.deltaTime;
			radius = _collider.radius * _transform.localScale.x;
		}
	}

	public void SetupIndex(int index) {
		_index = index;
	}

	public int GetIndex() {
		return _index;
	}

	IEnumerator DestroyObject() {
		_particle.Play ();
		yield return new WaitForSeconds (_particle.main.duration);
		Destroy (gameObject);
	}
}
