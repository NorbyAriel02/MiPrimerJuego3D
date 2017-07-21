using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIgame : MonoBehaviour {
	public Text textVel;
	public Text textTime;
	public Text textInicial;
	public Text textPlayerName;
	public Button btnContinue;
	public GameObject goBtnContinue;
	private myCarController car;
	private float delay;
	private bool end;
	// Use this for initialization
	void Start () {
		delay = 3;
		end = false;
		car = GameObject.FindGameObjectWithTag ("Player").GetComponent<myCarController> ();
		btnContinue.onClick.AddListener(Continue);
		Cursor.visible = false;
		textPlayerName.text = PlayerPrefs.GetString ("PlayerName");
		Time.timeScale = 1.0f;
	}


	void Continue()
	{
		SceneManager.LoadScene ("Records");
	}

	// Update is called once per frame
	void Update () {
		if (end)
			return;
		//apago el texto inicial luego de que arranca la carrera
		if (delay <= 0.0f)
			textInicial.enabled = false;

		//Marco la Salida
		if (car.GetTime () <= 0.0f) {
			textInicial.text = ((int)Mathf.Abs (car.GetTime ())).ToString();
		} else {
			delay -= Time.deltaTime;
			textInicial.text = "GO!!!";
			SetTextVel (car.GetVel ());
			SetTextTime (car.GetTime ());
		}		
	}

	public void SetTextVel(float vel)
	{
		textVel.text = "Vel.: " + vel.ToString("F2");
	}

	public void SetTextTime(float time)
	{
		textTime.text = "TIME: " + time.ToString("F2");
	}

	public void Finished()
	{
		Cursor.visible = true;
		delay = 3;
		end = true;
		textInicial.enabled = true;
		textInicial.text = "Finished!!";
		goBtnContinue.SetActive (true);
		string recods = PlayerPrefs.GetString ("Records");
		recods += car.GetTime ().ToString("F3").Trim() + "&" + textPlayerName.text.Trim () + "|";
		PlayerPrefs.SetString ("Records", recods);
	}
}
