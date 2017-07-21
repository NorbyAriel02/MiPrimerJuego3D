using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class myCarController : MonoBehaviour {
	public Transform[] wheels;
	public float motorPower;
	public float MaxTurn;
	public Rigidbody rbCar;

	private float instateatePower;
	private float brake;
	private float wheelTurn;
	private WheelCollider[] wheelsCollider;
	private float time;
	// Use this for initialization
	void Start () {
		seting ();
	}
	void seting()
	{
		rbCar.centerOfMass = new Vector3 (0, -0.5f, 0.3f);
		wheelsCollider = new WheelCollider[wheels.Length];
		for (int x = 0; x < wheels.Length; x++) {
			wheelsCollider [x] = getCollider (x);
		}
		time = -5;
	}
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (rbCar.velocity.magnitude);
		time += Time.deltaTime;
		if (time <= 0.0f)
			return;
		
		CarController ();

	}

	void CarController()
	{
		try
		{
			if(Input.GetKeyDown(KeyCode.O))
				seting();

			if (rbCar.velocity.magnitude < 15)
				MaxTurn = 15;
			else
				MaxTurn = 5;

			instateatePower = Input.GetAxis ("Vertical") * motorPower * Time.deltaTime;
			wheelTurn = Input.GetAxis ("Horizontal") * MaxTurn;
			brake = Input.GetKey (KeyCode.Space) ? rbCar.mass * 0.1f : 0.0f;

			//turn colliders
			wheelsCollider [0].steerAngle = wheelTurn;
			wheelsCollider [1].steerAngle = wheelTurn;

			//turn wheels 
			wheels[0].localEulerAngles = turnWheel(0);
			wheels[1].localEulerAngles = turnWheel(1);

			//spin wheels
			wheels[0].Rotate(-wheelsCollider[0].rpm / 60 * 100 * Time.deltaTime, 0,  0);
			wheels[1].Rotate(-wheelsCollider[0].rpm / 60 * 100 * Time.deltaTime, 0,  0);
			wheels[2].Rotate(-wheelsCollider[0].rpm / 60 * 100 * Time.deltaTime, 0,  0);
			wheels[3].Rotate(-wheelsCollider[0].rpm / 60 * 100 * Time.deltaTime, 0,  0);

			if (brake > 0.0f) {
				wheelsCollider [0].brakeTorque = brake;
				wheelsCollider [1].brakeTorque = brake;
				wheelsCollider [2].brakeTorque = brake;
				wheelsCollider [3].brakeTorque = brake;
				wheelsCollider [2].motorTorque = 0.0f;
				wheelsCollider [3].motorTorque = 0.0f;
			} else {
				wheelsCollider [0].brakeTorque = 0.0f;
				wheelsCollider [1].brakeTorque = 0.0f;
				wheelsCollider [2].brakeTorque = 0.0f;
				wheelsCollider [3].brakeTorque = 0.0f;
				wheelsCollider [2].motorTorque = instateatePower;
				wheelsCollider [3].motorTorque = instateatePower;
			}
		}
		catch(Exception ex) {
			Debug.Log (ex);
		}
	}

	Vector3 turnWheel(int n)
	{
		return new Vector3 (0, wheelsCollider [n].steerAngle*4, 0);
	}

	WheelCollider getCollider(int n)
	{
		return wheels [n].GetComponent<WheelCollider> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Explosive")
			col.transform.GetComponent<BarrelExplosion> ().active = true;
	}

	public float GetVel()
	{
		return rbCar.velocity.magnitude;
	}

	public float GetTime()
	{
		return time;
	}

	public void Finished()
	{
		time = -5;
	}

}
