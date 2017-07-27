using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Records: IComparable<Records>
{
	public string nombre;
	public float tiempo;

	public int CompareTo(Records obj)
	{
		/*Si es mayor return 1, sino -1 y si iguales 0*/
		return this.tiempo.CompareTo (obj.tiempo);
	}
}


public class RecordsController : MonoBehaviour {
	public Text[] Nombres;
	public Text[] Tiempos;
	public Button btnDone;
	void Awake()
	{
		//PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.HasKey ("Records")) {
			string[]  registros = PlayerPrefs.GetString ("Records").Split ('|');
			List<Records> records = new List<Records> ();
			foreach (string datos in registros) {
				if (datos != "") {
					string[] tiempo_y_nombre = datos.Split ('&');
					Records player = new Records ();
					player.tiempo = Convert.ToSingle(tiempo_y_nombre [0].Trim ());
					player.nombre = tiempo_y_nombre [1].Trim();
					records.Add (player);
				}

			}
			records.Sort ();
			int index = 0;
			foreach (Records record in records) {
				if (index >= 10)
					break;

				Nombres [index].text = record.nombre;
				Tiempos [index].text = record.tiempo.ToString();
				index++;
			}
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
