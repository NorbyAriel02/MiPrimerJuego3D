using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioMenu : MonoBehaviour {
	public float marcha = 0.1f;
	public AudioSource asEngine;
	public AudioSource asShot;
	private myCarController car;
	private GunController gun;
	private float timeBetweenShot = 0.1f;
	private float timer = 0;
	// Use this for initialization
	void Start () {		
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W)) {
			if(asEngine.pitch < 0.9f)
				asEngine.pitch += Time.deltaTime;
		} else {
			if(asEngine.pitch > 0.1f)
				asEngine.pitch  -= Time.deltaTime;
		}
		
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenShot) {
			asShot.Stop ();
			timer = 0.0f;
			asShot.Play ();
		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Explosive")
			col.transform.GetComponent<BarrelExplosion> ().explosion ();
	}
}
