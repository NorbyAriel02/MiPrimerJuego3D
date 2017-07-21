using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Button btnPlay;

	// Use this for initialization
	void Start () {
		btnPlay.onClick.AddListener (Play);	
	}
	void Play()
	{
		SceneManager.LoadScene ("PreMenu");
	}
	void Exit()
	{
		Application.Quit();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
