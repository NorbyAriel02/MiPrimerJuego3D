using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour {
	public float marcha = 0.1f;
	public AudioSource asEngine;
	public AudioSource asShot;
	private myCarController car;
	private GunController gun;
	private float timeBetweenShot;
	private float timer = 0;
	// Use this for initialization
	void Start () {		
		asEngine = GetComponent<AudioSource> ();
		car = GetComponent<myCarController> ();
		gun = GameObject.Find ("SpawnRay").GetComponent<GunController> ();
		timeBetweenShot = gun.GetTimeBetweenShot ();
	}
	
	// Update is called once per frame
	void Update () {
		float pitch = car.GetVel()/40.0f >= 0.1 ? car.GetVel()/40.0f:marcha;

		asEngine.pitch = pitch;

		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenShot) {
			asShot.Stop ();
			timer = 0.0f;
			asShot.Play ();
		}

	}
}
