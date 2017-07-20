using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour {
	public GameObject FXExplosion;

	public float radius = 5.0F;
	public float power = 10.0F;
	public bool active = false;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//se activa desde el script de la ametralladora
		if (active) {
			active = false;
			explosion ();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		
	}

	void explosion()
	{
		Instantiate (FXExplosion, transform.position, Quaternion.identity);
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb == null)
				continue;
			
			if (rb.tag == "Explosive" && rb.name != this.name)
				rb.GetComponent<BarrelExplosion> ().active = true;
			
			rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
		}
		Destroy (gameObject);
	}
}
