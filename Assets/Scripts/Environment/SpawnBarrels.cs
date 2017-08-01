using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrels : MonoBehaviour {
	public bool MakeDrop;
	private BarrelObjectController barrelController;

	// Use this for initialization
	void Start () {
		barrelController = GameObject.Find ("BarrelsObjectController").GetComponent<BarrelObjectController> ();
		MakeDrop = true;
	}

	// Update is called once per frame
	void Update () {
		if (MakeDrop) {
			MakeDrop = false;
			DropBarrel ();
		}
	}

	public void DropBarrel()
	{
		GameObject barrel = barrelController.GetBarrel (transform.position, Quaternion.identity);
		if (barrel == null)
			return;
		
		barrel.SetActive (true);
		barrel.GetComponent<BarrelExplosion> ().resitencia = 5;
		barrel.GetComponent<BarrelExplosion> ().alreadyExploted = false;
	}
}
