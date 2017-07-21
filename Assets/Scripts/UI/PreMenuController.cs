using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PreMenuController : MonoBehaviour {
	public Button btnGO;
	public InputField txtNombre;
	// Use this for initialization
	void Start () {
		btnGO.onClick.AddListener (Play);
	}

	void Play()
	{
		if (txtNombre.text != "") {
			PlayerPrefs.SetString ("PlayerName", txtNombre.text);
			SceneManager.LoadScene ("Nivel01");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
