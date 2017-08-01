using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXdisable : MonoBehaviour {
	private float timer;
	private float duration;
	void Start()
	{
		duration = GetComponent<ParticleSystem> ().main.duration;
		timer = duration;
	}

	void Update ()
	{
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			gameObject.SetActive (false);
			timer = duration;
		}

	}
}
