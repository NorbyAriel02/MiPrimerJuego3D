using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallRoadController : MonoBehaviour {
	private RoadController roadController;
	private SpawnBarrels spawnBarrel;
	// Use this for initialization
	void Start () {
		roadController = GameObject.Find ("RoadController").GetComponent<RoadController> ();
		spawnBarrel = GameObject.Find ("SpawnBarrels").GetComponent<SpawnBarrels> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			roadController.AdvanceTheLast ();
			spawnBarrel.DropBarrel ();
		}
	}
}