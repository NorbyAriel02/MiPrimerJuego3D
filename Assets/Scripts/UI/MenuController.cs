using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Button btnPlay;
	public Button btnRecords;
	public Button btnControllers;
	public Button btnExit;

	// Use this for initialization
	void Start () {
		btnPlay.onClick.AddListener (Play);	
		btnControllers.onClick.AddListener (Controllers);
		btnRecords.onClick.AddListener (Records);
		btnExit.onClick.AddListener (Exit);
		Time.timeScale = 1.0f;
	}
	void Play()
	{
		SceneManager.LoadScene ("PreMenu");
	}
	void Records()
	{
		SceneManager.LoadScene ("Records");
	}

	void Controllers()
	{
		SceneManager.LoadScene ("Controllers");
	}
	void Exit()
	{
		Application.Quit();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
