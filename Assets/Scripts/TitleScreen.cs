﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class TitleScreen : MonoBehaviour {

	public Canvas titleMenu; 
	public Button PlayScene; 
	public Button QuitButton; 
	public Button TutorialButton; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToPlayScene () {

		SceneManager.LoadScene ("CurrentWorkingScene"); 

	}

	public void Quit () {

		//Debug.Log ("QuitGame"); 
		Application.Quit();

	}

	public void GoToTutorial () {

		SceneManager.LoadScene (3); 

	}
}
