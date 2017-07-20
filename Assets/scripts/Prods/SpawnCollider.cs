using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour {
	private RespawnController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponentInParent<RespawnController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			controller.next ();
			Debug.Log ("Paso por "  + controller.GetSpawnActive());
		}
	}
}
