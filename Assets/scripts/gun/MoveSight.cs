using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = mousePos.z + 30;
		// le estoy mandando  = 10 a la funcion

		transform.position = Camera.main.ScreenToWorldPoint(mousePos);
	}
}
