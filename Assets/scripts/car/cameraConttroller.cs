using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraConttroller : MonoBehaviour {
	public Transform target;
	public float speed;
	public float speedRotation;
	public float distanceY;
	public float distanceZ;
	public Rigidbody rbCam;
	public Rigidbody rbCar;
	// Use this for initialization
	private Quaternion rotInitial;
	private float timer = 0;
	void Start () {
		rotInitial = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		timer += Time.deltaTime;

		if (transform.rotation == target.rotation)
			timer = 0;
		
		float velocity = 0;
		transform.localPosition = new Vector3(target.localPosition.x, target.localPosition.y + distanceY, target.localPosition.z - distanceZ);
		//transform.localRotation = target.localRotation;

		if (Mathf.Abs (rbCar.velocity.z) > speed)
			velocity = Mathf.Abs (rbCar.velocity.z) + speed;
		else
			velocity = speed;
			
		if (Vector3.Distance (target.position, transform.position) > distanceZ) {
			transform.LookAt (target);

			rbCam.velocity = transform.forward * velocity;			
		} else {
			transform.LookAt (target);

			rbCam.velocity = new Vector3 (0, 0, 0);
		}
		//Debug.Log (rbCam.velocity.z + " - " + rbCar.velocity.z);
	}
}
