using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			shoot ();
		}
	}

	void shoot()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 350)) {
			//Debug.DrawLine (ray.origin, hit.point);	

			if (hit.transform.tag == "Explosive")
				hit.transform.GetComponent<BarrelExplosion> ().active = true;
		}
	}
}
