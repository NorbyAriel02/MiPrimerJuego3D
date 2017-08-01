using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour {
	public float radius = 5.0F;
	public float power = 10.0F;

	public bool alreadyExploted = false;
	public  int resitencia = 10;
	private SystemParticleController FXController;
	private Vector3 FxPosition;
	void Start()
	{
		FXController = GameObject.Find ("FXController").GetComponent<SystemParticleController> ();

	}

	void OnCollisionEnter(Collision col)
	{
		
	}

	public void explosion()
	{
		if (alreadyExploted)
			return;

		resitencia--;
		if (resitencia > 0)
			return;

		alreadyExploted = true;

		FxPosition = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);

		ParticleSystem fx = FXController.GetFxExplosion (FxPosition, Quaternion.identity);

		if (fx == null)
			return;
		
		fx.gameObject.SetActive (true);

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb == null)
				continue;
			
			if (rb.tag == "Explosive" && rb.GetInstanceID () != this.GetInstanceID ())
				rb.GetComponent<BarrelExplosion> ().explosion ();
			
			rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
		}

		//Destroy (gameObject);
		gameObject.SetActive(false);
	}
}
