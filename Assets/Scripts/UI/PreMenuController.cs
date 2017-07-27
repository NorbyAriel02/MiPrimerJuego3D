using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PreMenuController : MonoBehaviour {
	public Button btnGO;
	public Button btnBack;
	public InputField txtNombre;
	// Use this for initialization
	void Start () {
		btnGO.onClick.AddListener (Play);
		btnBack.onClick.AddListener (Back);
	}

	void Back()
	{
		SceneManager.LoadScene ("Menu");
	}
	void Play()
	{
		if (txtNombre.text != "") {
			string nombre = "";
			nombre = txtNombre.text.Trim();

			if (txtNombre.text.Length > 6)
				nombre = txtNombre.text.Substring (0, 5);
			
			PlayerPrefs.SetString ("PlayerName", nombre);
			SceneManager.LoadScene ("Nivel01");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
