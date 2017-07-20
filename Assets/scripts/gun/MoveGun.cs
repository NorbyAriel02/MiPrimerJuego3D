using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour {
	public Transform sight;
	void Awake()
	{
		
	}

	void FixedUpdate()
	{
		//Mathf.Clamp ();
		Vector3 newLookAt = new Vector3(sight.position.x, transform.position.y, sight.position.z);
		transform.LookAt (newLookAt);
	}
}
