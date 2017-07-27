using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {
	public Transform car;
	public Transform[] ListRespawn;
	private int spawnActive = 0;
	private Quaternion rotationCar;
	private Rigidbody rbCar;
	// Use this for initialization
	void Start () {
		rotationCar = car.rotation;
		rbCar = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			CarRespawn (GetSpawnActive ());
		
	}

	public void CarRespawn(int n)
	{
		rbCar.velocity = new Vector3(0, 0, rbCar.velocity.z);

		rbCar.angularVelocity = Vector3.zero;
		car.position = ListRespawn [n].position;
		car.rotation = rotationCar;
	}

	public int GetSpawnActive()
	{
		return spawnActive;
	}

	public void next()
	{
		spawnActive++;
		//llega al final
		if (spawnActive > ListRespawn.Length - 1)
			spawnActive = 0;
	}
}
