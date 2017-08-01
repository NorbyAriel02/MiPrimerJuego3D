using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public float timeBetweenShot = 1;
	public float powerShot = 8000;
	public GameObject particulas;
	public float range = 30;
	private float timer = 0;

	LineRenderer gunLine;
	// Use this for initialization
	void Start () {
		gunLine = GetComponent <LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenShot) {
			timer = 0.0f;
			shoot ();
		} else {
			DisableEffects ();
		}
	}

	public float GetTimeBetweenShot()
	{
		return timeBetweenShot;
	}

	public void DisableEffects ()
	{
		gunLine.enabled = false;	
	}

	void shoot()
	{
		Ray ray = new Ray (transform.position, transform.forward);// Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		if (Physics.Raycast (ray, out hit, 350)) {
			Debug.DrawLine (ray.origin, hit.point);	

			gunLine.SetPosition (1, hit.point);

			if (hit.transform != null)
				Instantiate (particulas, hit.point, Quaternion.identity);

			if (hit.transform.tag == "Barrel") {
				hit.transform.GetComponent<Rigidbody> ().AddForce (transform.forward*powerShot);
			}

			if (hit.transform.tag == "Explosive") {				
				hit.transform.GetComponent<BarrelExplosion> ().explosion ();
			}
		}
		else
		{
			gunLine.SetPosition (1, ray.origin + ray.direction * range);
		}
	}
}
