using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controllers : MonoBehaviour {
	public Button btnDone;

	// Use this for initialization
	void Start () {
		btnDone.onClick.AddListener (Done);	
	}
	void Done()
	{
		SceneManager.LoadScene ("Menu");
	}
	// Update is called once per frame
	void Update () {
	}
}
