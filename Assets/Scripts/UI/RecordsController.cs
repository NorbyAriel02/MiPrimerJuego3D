using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecordsController : MonoBehaviour {
	public Text[] Nombres;
	public Text[] Puntos;
	public Button btnDone;
	void Awake()
	{
		//PlayerPrefs.DeleteAll ();
		string[] nombres = { "","","","","","","","","",""};
		string[] puntos = { "","","","","","","","","",""};
		int index = 0;
		if (PlayerPrefs.HasKey ("Records")) {
			string[]  datos = PlayerPrefs.GetString ("Records").Split ('|');
			List<string> records = new List<string> ();
			foreach (string s in datos) {
				if(s != "")
					records.Add (s);
			}
			records.Sort ();
			foreach (string dato in records) {
				string[] row = dato.Split ('&');
				puntos [index] = row [0];
				nombres [index] = row [1];
				index++;

				if (index >= 10)
					break;
			}
		}

		for (int x = 0; x < puntos.Length; x++) {
			Nombres [x].text = nombres [x];
			Puntos [x].text = puntos [x];
		}

		btnDone.onClick.AddListener (Done);
	}
	void Done()
	{
		SceneManager.LoadScene ("Menu");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
