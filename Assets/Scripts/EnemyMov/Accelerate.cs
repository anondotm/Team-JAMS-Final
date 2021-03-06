﻿using UnityEngine;
using System.Collections;

public class Accelerate : MonoBehaviour {

	public GameObject highlight;
	public GameObject transparent;

	public string enemyIdentity;
	Renderer enemyRend; 
	bool isCanonLooking = false; 
	public float accelSpeed; 

	// Update is called once per frame

	void Start () {
		transparent = this.transform.Find ("InvisiVirus").gameObject;
		highlight = this.transform.Find ("Highlight").gameObject;

		enemyRend = GetComponent<Renderer> ();
		accelSpeed = 1.4f; //+ PlayerPrefs.GetInt ("enemySpeedBonus"); //speed will increase every level


	}

	void Update (){
		//If the Canon is not looking at the object, then set the color of the ennemy to grey.
		if (!isCanonLooking) {
			//enemyRend.material.SetColor ("_Color", Color.grey);
			transparent.SetActive (true);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		goToPlayer(); //call function 
		accelSpeed += .01f; 
	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *accelSpeed* Time.deltaTime;
	}

	void OnTriggerEnter( Collider canon){
		if (canon.name == "aim") {
			isCanonLooking = true;
			getColor ();
		}
	}
	void OnTriggerStay( Collider canon){
		if (canon.name == "aim") {
			isCanonLooking = true;
			getColor ();
		}
	}
	void OnTriggerExit( Collider canon){
		if (canon.name == "aim") {
			isCanonLooking = false;
			highlight.SetActive (false);
		}
	}
	void getColor(){
		//		if (enemyIdentity == "Red") {
		//			enemyRend.material.SetColor ("_Color", Color.red);
		//		} else if (enemyIdentity == "Blue") {
		//			enemyRend.material.SetColor ("_Color", Color.blue);
		//		} else {
		//			enemyRend.material.SetColor ("_Color", Color.green);
		//		}
		highlight.SetActive (true);
		transparent.SetActive (false);
	}
}
