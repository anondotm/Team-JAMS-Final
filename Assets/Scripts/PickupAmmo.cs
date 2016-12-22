using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickupAmmo : MonoBehaviour {

//SCRIPT BELONGING TO PLAYER 2


	//object referencing cannon
	public GameObject cannonObject;

	//object referencing exclamation
	public GameObject promptObject;

	//GameObject currently being "looked" at
	public GameObject currentHighlight;
	//GameObject currently being "touched"
	public GameObject touchingObject;
	public Vector3 touchingObjectScale;


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

	void Update () {

		//VERSION 1: COLLISION-TRIGGER based picking up/dropping off

		if (gameObject.name == "Zone Ammo Character") {
			if (touchingObject != null) {
				
				if (touchingObject.GetComponent<AmmoSource> () == true) {

					if (Input.GetKeyDown (KeyCode.Space)) {

						//check if player can pick up ammo (hands aren't full)
						if (heldAmmoSize < 3) {

							if (touchingObject.tag == "Ammo1") {
								heldAmmo.Add ("Red");
								instantiateAmmo (physicalRed);
								updateText ();
								touchingObject.GetComponent<AmmoSource> ().tookAmmo ();
							} else if (touchingObject.tag == "Ammo2") {
								heldAmmo.Add ("Green");
								instantiateAmmo (physicalGreen);
								updateText ();
								touchingObject.GetComponent<AmmoSource> ().tookAmmo ();
							} else if (touchingObject.tag == "Ammo3") {
								heldAmmo.Add ("Blue");
								instantiateAmmo (physicalBlue);
								updateText ();
								touchingObject.GetComponent<AmmoSource> ().tookAmmo ();
							}
								
						}

					} else {

						//feedback only activates if the player can pick something up
						if (heldAmmoSize < 3) {
							promptObject.SetActive (true); //activates exclamation mark
							touchingObject.transform.Find ("Highlight").gameObject.SetActive (true); //makes visible the objects "highlight"
							heldAmmoPosition [heldAmmoSize].gameObject.SetActive (true);
						} else {
							promptObject.SetActive (false);
							touchingObject.transform.Find ("Highlight").gameObject.SetActive (false);
						}
					}
						
				} 			

				//when players interact with the dumbwaiter, the game actually just "adds" the player's ammo to the Cannon Object's ammo list ("cannonAmmo");
				else if (touchingObject.tag == "DumbWaiter") {

					if (heldAmmoSize > 0) {
						touchingObject.transform.Find ("Highlight").gameObject.SetActive (true);
						promptObject.SetActive (true);
					} else {
						touchingObject.transform.Find ("Highlight").gameObject.SetActive (false);
						promptObject.SetActive (false);
					}

					if (Input.GetKeyDown (KeyCode.Space)) {
						//transfers ammo to player 1 and 
						cannonObject.GetComponent<ShootBullet> ().cannonAmmo.AddRange (heldAmmo);
						heldAmmo.Clear ();
						//clearPhysicalAmmo ();
						sendPhysicalAmmo();
				
						updateText ();

						cannonObject.GetComponent<ShootBullet> ().textUpdate ();

					}

				}

				else if (touchingObject.tag == "Trash") {

					if (heldAmmoSize > 0) {
						touchingObject.transform.Find ("Highlight").gameObject.SetActive (true);
						promptObject.SetActive (true);
					} else {
						touchingObject.transform.Find ("Highlight").gameObject.SetActive (false);
						promptObject.SetActive (false);
					}

					if (Input.GetKeyDown (KeyCode.Space)) {
						heldAmmo.Clear ();
						clearPhysicalAmmo ();

						updateText ();
					}

				}

			} else {

				if (heldAmmoSize < 3) {
					heldAmmoPosition [heldAmmoSize].gameObject.SetActive (false);
				}
			}
		}

		//**********************************************************************************************************************************************

		//VERSION 2: SPHERECAST based picking up/dropping off

		else {

		//create and project a spherecast
		Ray ammoCheckRay = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.SphereCast (ammoCheckRay, .55f, out hit, 2.35f)) { //default was .5f, 2.5f

			//stores the object that is currently being viewed in "currentHighlight"
			currentHighlight = hit.collider.gameObject;

			//if the spherecast hits an AMMO REPOSITORY (checks if object has AmmoSource script)
			if (hit.collider.GetComponent<AmmoSource> () == true) {
				

				if (Input.GetKeyDown (KeyCode.Space)) {

					//check if player can pick up ammo (hands aren't full)
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

						//COMMENTED OUT WEIGHT-DEPENDENT SPEED
						//currentMoveSpeed -= (initialMoveSpeed * .1f);
						//this.gameObject.GetComponent<CharacterMovement> ().playerSpeed = currentMoveSpeed;

					}

				} 

				//If the player is simply "looking" at the AMMO REPOSITORY (activate feedback)
				else {

					//feedback only activates if the player can pick something up
					if (heldAmmoSize < 3) {
						promptObject.SetActive (true); //activates exclamation mark
						currentHighlight.transform.Find ("Highlight").gameObject.SetActive (true); //makes visible the objects "highlight"
						heldAmmoPosition [heldAmmoSize].gameObject.SetActive (true);
					} 

					else {
						promptObject.SetActive (false);
						currentHighlight.transform.Find ("Highlight").gameObject.SetActive (false);
					}
				}

				if (heldAmmoSize > 0) {
					heldAmmoPosition [heldAmmo.Count - 1].gameObject.SetActive (false);
				}

			}
				

			//players can use the trash to drop off or "clear" held ammo
			else if (hit.collider.tag == "Trash") {

				if (heldAmmoSize > 0) {
					currentHighlight.transform.Find ("Highlight").gameObject.SetActive (true);
					promptObject.SetActive (true);
				} else {
					currentHighlight.transform.Find ("Highlight").gameObject.SetActive (false);
					promptObject.SetActive (false);
				}

				if (Input.GetKeyDown (KeyCode.Space)) {
					heldAmmo.Clear ();
					clearPhysicalAmmo ();

					updateText ();
				}

			}


				
			//when players interact with the dumbwaiter, the game actually just "adds" the player's ammo to the Cannon Object's ammo list ("cannonAmmo");
			else if (hit.collider.tag == "DumbWaiter") {

				if (heldAmmoSize > 0) {
					currentHighlight.transform.Find ("Highlight").gameObject.SetActive (true);
					promptObject.SetActive (true);
				} else {
					currentHighlight.transform.Find ("Highlight").gameObject.SetActive (false);
					promptObject.SetActive (false);
				}

				if (Input.GetKeyDown (KeyCode.Space)) {
						//if (cannonObject.GetComponent<ShootBullet> ().cannonAmmo.Count < 7) {
							//transfers ammo to player 1
							cannonObject.GetComponent<ShootBullet> ().cannonAmmo.AddRange (heldAmmo);
							heldAmmo.Clear ();
							sendPhysicalAmmo ();

							updateText ();

							cannonObject.GetComponent<ShootBullet> ().textUpdate ();
						//}

				}

			}

	
		} else {
			promptObject.SetActive (false);
			currentHighlight.transform.Find ("Highlight").gameObject.SetActive (false);
			if (heldAmmoSize < 3) {
				heldAmmoPosition [heldAmmoSize].gameObject.SetActive (false);
			}
		}
		}

	}
		
	void FixedUpdate () {

		//updates heldAmmoSize with length/size of heldAmmo
		heldAmmoSize = heldAmmo.Count;

	}


	//**********************************************************************************

	//OTHER FUNCTIONS

	void OnTriggerStay (Collider stay) {
		touchingObject = stay.gameObject;
		//touchingObjectScale = touchingObject.transform.localScale;
		//touchingObject.transform.localScale *= 1.1f;
	}

	void OnTriggerEnter (Collider enter) {
		touchingObject = enter.gameObject;
		touchingObjectScale = touchingObject.transform.localScale;
		touchingObject.transform.localScale *= 1.1f;
	}

	void OnTriggerExit (Collider exited) {
		touchingObject = null;
		promptObject.SetActive (false);
		exited.gameObject.transform.localScale = touchingObjectScale;
		exited.transform.Find ("Highlight").gameObject.SetActive (false);
	}

	void updateText() {
		//updates UI element with heldAmmo contents!
		//heldAmmoText.GetComponent<Text>().text = "Ammo held:";

		if (heldAmmo.Count > 0) {
			//for (int i = 0; i <= heldAmmoSize; i++) {
				//heldAmmoText.GetComponent<Text> ().text += " " + heldAmmo [i];
			//}
		}

	}

	//spawns ammo in the players hands after interactoin with repository
	public void instantiateAmmo(GameObject ammoType) {

		GameObject newStack = (GameObject)Instantiate (ammoType, heldAmmoPosition [heldAmmoSize].position, Quaternion.identity);
		newStack.transform.parent = this.transform;
		physicalAmmoList.Add (newStack);

	}

	//destroys the ammo in the player hand
	public void clearPhysicalAmmo () {
		for (int i = 0; i < physicalAmmoList.Count; i++) {
			Destroy (physicalAmmoList [i]);
		}

		physicalAmmoList.Clear ();
	}

	//sends ammo to the beyond!
	public void sendPhysicalAmmo () {
		for (int i = 0; i < physicalAmmoList.Count; i++) {
			physicalAmmoList [i].GetComponent<HeldAmmoScript> ().StartCoroutine ("MoveCoroutine");
		}
		physicalAmmoList.Clear();
	}
		
}
