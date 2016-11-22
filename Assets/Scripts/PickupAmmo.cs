using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickupAmmo : MonoBehaviour {

	//object referencing cannon
	public GameObject cannonObject;

	// records initial movement speed for character on start
	float initialMoveSpeed = 0;
	// gets and stores curren movespeed from "Movement" script so we can manipulate it based on ammoHeld
	public float currentMoveSpeed;


	//list that stores player's "held" ammo
	public List<string> heldAmmo = new List<string>(); 
	//updates with size of heldAmmo list, used to limit amt. of ammo carried
	public int heldAmmoSize;
	//UI text element displaying ammo held
	public GameObject heldAmmoText;


	void Start () {
		//stores intiial movement speed of character so we can manipulate it based on ammoHeld
		//initialMoveSpeed = GetComponent<Movement> ().movespeed;
	}
	
	// Update is called once per frame
	void Update () {

		//create and project a spherecast
		Ray ammoCheckRay = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast(ammoCheckRay,.5f, out hit, 2f)){
			
			//Debug.Log ("There's something there...");

			if (Input.GetKeyDown (KeyCode.Space)) {

				//if the raycast hits an ammo repository (checks if object has AmmoSource script
				if (hit.collider.GetComponent<AmmoSource>() == true) {

					//check if player is not holding 3+ ammo
					if (heldAmmoSize < 3) {
						
						if (hit.collider.tag == "Ammo1") {
							heldAmmo.Add ("Red");
						} else if (hit.collider.tag == "Ammo2") {
							heldAmmo.Add ("Green");
						} else if (hit.collider.tag == "Ammo3") {
							heldAmmo.Add ("Blue");
						} 


						currentMoveSpeed -= initialMoveSpeed * .2f;
						//GetComponent<Movement> ().movespeed = currentMoveSpeed;
					
					//if they are, tell them to drop something off!
					} else {
						Debug.Log ("Drop some stuff!");
					}

				}

				//players can use the trash to drop off or "clear" held ammo
				else if (hit.collider.tag == "Trash") {
					heldAmmo.Clear ();

					currentMoveSpeed = initialMoveSpeed;
					GetComponent<Movement> ().movespeed = currentMoveSpeed;
				
					//when players interact with the dumbwaiter, the game actually just "adds" the player's ammo to the Cannon Object's ammo list ("cannonAmmo");
				} else if (hit.collider.tag == "DumbWaiter") {
					cannonObject.GetComponent<ShootBullet> ().cannonAmmo.AddRange (heldAmmo);
					heldAmmo.Clear ();

					cannonObject.GetComponent<ShootBullet> ().textUpdate();

					currentMoveSpeed = initialMoveSpeed;
					//GetComponent<Movement> ().movespeed = currentMoveSpeed;
				}

				updateText ();
			}

		}
	}

	void FixedUpdate () {

		//updates heldAmmoSize with length/size of heldAmmo
		heldAmmoSize = heldAmmo.Count;

	}

	void updateText() {
		//updates UI element with heldAmmo contents!
		heldAmmoText.GetComponent<Text>().text = "Ammo held:";

		if (heldAmmoSize > 0) {
			for (int i = 0; i <= heldAmmoSize; i++) {
				heldAmmoText.GetComponent<Text> ().text += " " + heldAmmo [i];
			}
		}
	}
}
