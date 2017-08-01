using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphera : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move()
	{
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		Vector3 dir = new Vector3(hor, 0, ver);
		rb.velocity = dir * Time.deltaTime * 200;
	}
}
