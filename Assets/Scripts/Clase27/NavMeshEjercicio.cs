using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEjercicio : MonoBehaviour {
	public Transform[] targets;
	// Use this for initialization
	private NavMeshAgent agent;
	private int index = 0;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (targets [index].position);
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 2) {
			index++;
			if (index >= targets.Length)
				index = 0;
			
			agent.SetDestination (targets [Random.Range(0, 5)].position);
		}
			
	}
}
