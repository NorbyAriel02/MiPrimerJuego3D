using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChangeController : MonoBehaviour {
	public Vector3[] positions;
	// Use this for initialization
	private int index;
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			index++;
			if (index >= positions.Length)
				index = 0;
			
			transform.localPosition = positions [index];
		}
	}
}
