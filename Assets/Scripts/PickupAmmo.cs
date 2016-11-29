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

	//Array with positions to instantiate "physical" ammo
	public GameObject physicalRed;
	public GameObject physicalGreen;
	public GameObject physicalBlue;
	public Transform[] heldAmmoPosition;
	public List<GameObject> physicalAmmoList = new List<GameObject>();


	void Start () {
		//stores intiial movement speed of character so we can manipulate it based on ammoHeld
		initialMoveSpeed = this.gameObject.GetComponent<CharacterMovement> ().playerSpeed;
		currentMoveSpeed = initialMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.F)) {
			//instantiateAmmo ();
		}

		//create and project a spherecast
		Ray ammoCheckRay = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ammoCheckRay, .5f, out hit, 2.5f)) {
			
			//Debug.Log ("There's something there...");

			//if the raycast hits an ammo repository (checks if object has AmmoSource script
			if (hit.collider.GetComponent<AmmoSource> () == true) {

				if (Input.GetKeyDown (KeyCode.Space)) {


					//check if player is not holding 3+ ammo
					if (heldAmmoSize < 3) {
						
						if (hit.collider.tag == "Ammo1") {
							heldAmmo.Add ("Red");
							instantiateAmmo (physicalRed);
							updateText ();
						} else if (hit.collider.tag == "Ammo2") {
							heldAmmo.Add ("Green");
							instantiateAmmo (physicalGreen);
							updateText ();
						} else if (hit.collider.tag == "Ammo3") {
							heldAmmo.Add ("Blue");
							instantiateAmmo (physicalBlue);
							updateText ();
						} 

						//updateText ();


						currentMoveSpeed -= (initialMoveSpeed * .2f);
						this.gameObject.GetComponent<CharacterMovement> ().playerSpeed = currentMoveSpeed;

					}

				} else {
					if (heldAmmoSize < 3) {
						heldAmmoPosition [heldAmmoSize].gameObject.SetActive (true);
					}
				}

				if (heldAmmoSize > 0) {
					heldAmmoPosition [heldAmmo.Count - 1].gameObject.SetActive (false);
				}

			}
				

			//players can use the trash to drop off or "clear" held ammo
			else if (hit.collider.tag == "Trash") {

				if (Input.GetKeyDown (KeyCode.Space)) {
					heldAmmo.Clear ();
					clearPhysicalAmmo ();

					currentMoveSpeed = initialMoveSpeed;
					this.gameObject.GetComponent<CharacterMovement> ().playerSpeed = currentMoveSpeed;

					updateText ();
				}

			}


				
			//when players interact with the dumbwaiter, the game actually just "adds" the player's ammo to the Cannon Object's ammo list ("cannonAmmo");
			else if (hit.collider.tag == "DumbWaiter") {

				if (Input.GetKeyDown (KeyCode.Space)) {
					cannonObject.GetComponent<ShootBullet> ().cannonAmmo.AddRange (heldAmmo);
					heldAmmo.Clear ();
					clearPhysicalAmmo ();

					currentMoveSpeed = initialMoveSpeed;
					this.gameObject.GetComponent<CharacterMovement> ().playerSpeed = currentMoveSpeed;

					updateText ();

					cannonObject.GetComponent<ShootBullet> ().textUpdate ();

				}

			}

			//whenever you press space, updates the text
			//updateText ();
		} else {
			if (heldAmmoSize < 3) {
				heldAmmoPosition [heldAmmoSize].gameObject.SetActive (false);
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

		if (heldAmmo.Count > 0) {
			for (int i = 0; i <= heldAmmoSize; i++) {
				heldAmmoText.GetComponent<Text> ().text += " " + heldAmmo [i];
			}
		}

	}

	public void instantiateAmmo(GameObject ammoType) {

		GameObject newStack = (GameObject)Instantiate (ammoType, heldAmmoPosition [heldAmmoSize].position, Quaternion.identity);
		newStack.transform.parent = this.transform;
		physicalAmmoList.Add (newStack);

	}

	public void clearPhysicalAmmo () {
		for (int i = 0; i < physicalAmmoList.Count; i++) {
			Destroy (physicalAmmoList [i]);
		}
		physicalAmmoList.Clear ();
	}
}
