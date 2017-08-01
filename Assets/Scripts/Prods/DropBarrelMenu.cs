using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBarrelMenu : MonoBehaviour {
	public GameObject barrel;
	public float timebetweenBarrel = 3;
	private float timer = 0;
	private BarrelObjectController barrelController;
	// Use this for initialization
	void Start () {
		barrelController = GameObject.Find ("BarrelsObjectController").GetComponent<BarrelObjectController> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebetweenBarrel) {
			GameObject barrel = barrelController.GetBarrel (transform.position, Quaternion.identity);
			if (barrel == null)
				return;

			barrel.SetActive (true);
			barrel.GetComponent<BarrelExplosion> ().resitencia = 1;
			barrel.GetComponent<BarrelExplosion> ().alreadyExploted = false;
			timer = 0;
		}
	}
}
