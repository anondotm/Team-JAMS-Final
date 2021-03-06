﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class HealthManager : MonoBehaviour {

	public int Health = 10; 
	public Text HealthText;
	//public Slider HealthSlider;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log (Health);
		SetHealthText (); 
		if(Health <= 0) {

			Mathf.Clamp (Health, 0, 10); //limit the health within this range 
			SceneManager.LoadScene ("GameOver"); 

		}
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	
	}

	public void SetHealthText() {

		HealthText.text = "Health: " + Health.ToString (); 
		//HealthSlider.value = Health;

	}

	public int GetHealth() {

		return Health; 

	}

	public void SetHealth(int damage) {

		Health -= damage; 

	}
}
