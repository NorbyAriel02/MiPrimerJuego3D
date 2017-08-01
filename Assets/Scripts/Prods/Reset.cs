using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	public Transform car;
	// Use this for initialization
	private Vector3 pos;
	private Quaternion rot;
	private Rigidbody rbCar;
	void Start () {
		pos = car.position;
		rot = car.rotation;
		rbCar = car.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			rbCar.velocity = Vector3.zero;
			//rbCar.angularDrag = 0;
			rbCar.angularVelocity = Vector3.zero;
			other.transform.position = pos;
			other.transform.rotation = rot;
		} else {
			other.gameObject.SetActive (false);
		}
	}
}
