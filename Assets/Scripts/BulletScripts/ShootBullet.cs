﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootBullet : MonoBehaviour {

	//List for bullets
	public List<string> cannonAmmo = new List<string>();
	public GameObject heldAmmoText;

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
				Instantiate (bullet, spawner.position, playerT.rotation);
				cannonAmmo.RemoveAt (cannonAmmo.Count - 1);
				textUpdate();
			}
		}
	}

	public void textUpdate() {
		//updates UI element with heldAmmo contents!
		heldAmmoText.GetComponent<Text>().text = "Ammo held:";

		for (int i = 0; i <= cannonAmmo.Count; i++) {
			heldAmmoText.GetComponent<Text> ().text += " " + cannonAmmo [i];
		}
	}
}
