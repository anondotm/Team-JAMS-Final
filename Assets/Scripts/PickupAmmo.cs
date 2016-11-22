using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickupAmmo : MonoBehaviour {

	public GameObject cannonObject;

	//list that stores player's "held" ammo
	public List<int> heldAmmo = new List<int>(); 
	//updates with size of heldAmmo list, used to limit amt. of ammo carried
	public int heldAmmoSize;

	public GameObject heldAmmoText;

	void Start () {
		
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
							heldAmmo.Add (1);
						} else if (hit.collider.tag == "Ammo2") {
							heldAmmo.Add (2);
						} else if (hit.collider.tag == "Ammo3") {
							heldAmmo.Add (3);
						} 
					
					//if they are, tell them to drop something off!
					} else {
						Debug.Log ("Drop some stuff!");
					}

				}

				//players can use the trash to drop off or "clear" held ammo
				else if (hit.collider.tag == "Trash") {
					heldAmmo.Clear ();
				
					//when players interact with the dumbwaiter, the game actually just "adds" the player's ammo to the Cannon Object's ammo list ("cannonAmmo");
				} else if (hit.collider.tag == "DumbWaiter") {
					cannonObject.GetComponent<PlayerController> ().cannonAmmo.AddRange (heldAmmo);
					heldAmmo.Clear ();
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

		for (int i = 0; i <= heldAmmoSize; i++) {
			heldAmmoText.GetComponent<Text> ().text += " " + heldAmmo [i];
		}
	}
}
