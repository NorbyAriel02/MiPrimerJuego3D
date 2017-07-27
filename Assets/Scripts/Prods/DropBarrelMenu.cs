using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBarrelMenu : MonoBehaviour {
	public GameObject barrel;
	public float timebetweenBarrel = 3;
	private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebetweenBarrel) {
			Instantiate (barrel, transform.position, Quaternion.identity);
			timer = 0;
		}
	}
}
