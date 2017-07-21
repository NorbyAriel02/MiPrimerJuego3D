using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishController : MonoBehaviour {
	public Text textVel;
	public Text textTime;
	public Text textInicial;

	private myCarController car;
	private float delay;
	private bool end;
	private bool onlyOne = true;
	private UIgame ui;
	// Use this for initialization
	void Start () {
		delay = 2;
		car = GameObject.FindGameObjectWithTag ("Player").GetComponent<myCarController> ();
		end = false;
		ui = GameObject.Find ("CanvasUI").GetComponent<UIgame> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!end)
			return;

		delay -= Time.deltaTime;

		if (delay <= 0.0f) {
			Time.timeScale = 0.0f;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player" && onlyOne) {
			ui.Finished ();
			end = true;
			onlyOne = false;
		}
	}
}
