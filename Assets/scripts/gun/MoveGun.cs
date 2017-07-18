using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour {
	public Transform sigh;
	Camera thisCamera;

	void Awake()
	{
		thisCamera = Camera.main;
	}

	void Update()
	{
		Vector3 mousePos = Input.mousePosition;

		Vector3 mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);
		//Mathf.Clamp ();
		Vector3 newLookAt = new Vector3(sigh.position.x, transform.position.y, sigh.position.z);

		transform.LookAt (newLookAt);
		//Quaternion.Euler (sigh.position);

		//transform.rotation = Quaternion.FromToRotation (transform.position, sigh.position);
		//transform.rotation = Quaternion.LookRotation(sigh.position);
	}

}
