﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootBullet : MonoBehaviour {

	//List for Ammo
	public List<string> cannonAmmo = new List<string>();
	public GameObject heldAmmoText;

	//Array for bullet types. "nextAmmo" checks what type of ammo will be used next.
	public GameObject[] bulletArray;
	public string nextAmmo;

	//We know where to spawn the bullets
	public Transform spawner;

	//We know what bullets to spawn. Probably will turn this into an array for all the diff bullets
	public GameObject bullet;

	GameObject player;
	Transform playerT;

	//Tried to get this to talk to the ammo container. Currently not working
//	public GameObject ammoContainer;
//	public AmmoHolder theAmmo;
//	int totalAmmo;
	// Use this for initialization

	void Start () {
		//Finds the camera as that is what will define the local rotation for the bulets
		player = GameObject.FindGameObjectWithTag ("MainCamera");
		//gets the transform of the camera
		playerT = player.GetComponent<Transform> ();
		//theAmmo = ammoContainer.GetComponent<AmmoHolder> ();
	}

	// Update is called once per frame
	void Update () {
		//totalAmmo = theAmmo.getAmmo ();
		//If you press mouse button, ammo will be shot from the cannon.
		if (Input.GetMouseButtonDown (0)) {
			//If you have at enough ammo to shoot...
			if (cannonAmmo.Count > 0) {
				//Shoot type of bullet based on what ammo is next in the cannonAmmo list ("nextAmmo")
				if (nextAmmo == "Red") {
					Instantiate (bulletArray[0], spawner.position, playerT.rotation);
				} else if (nextAmmo == "Green") {
					Instantiate (bulletArray[1], spawner.position, playerT.rotation);
				} else if (nextAmmo == "Blue") {
					Instantiate (bulletArray[2], spawner.position, playerT.rotation);
				} 
				cannonAmmo.RemoveAt (0);
				textUpdate();
			}
		}
	}

	public void textUpdate() {
		//After being fed ammo or shooting bullet, update information for the next ammo type the cannon will shoot
		if (cannonAmmo.Count > 0) {
			nextAmmo = cannonAmmo [0];
		}

		//updates UI element with heldAmmo contents!
		heldAmmoText.GetComponent<Text>().text = "Ammo held:";

		for (int i = 0; i <= cannonAmmo.Count; i++) {
			heldAmmoText.GetComponent<Text> ().text += " " + cannonAmmo [i];
		}
	}
}
