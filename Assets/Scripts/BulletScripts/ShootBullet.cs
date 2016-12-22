using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootBullet : MonoBehaviour {

	public GameObject soundObject;
	public GameObject ammoCountText;

	//List for Ammo
	public List<string> cannonAmmo = new List<string>();
	public GameObject heldAmmoText;

	//Array for bullet types. "nextAmmo" checks what type of ammo will be used next.
	public GameObject[] bulletArray;
	public string nextAmmo;

	//Array for Default, Red, Green, and Blue material to indicate what ammo is next (or if the cannon has any ammo at all)
	public GameObject nextAmmoIndicator;
	public GameObject nextAmmoIndicator1;
	public GameObject nextAmmoIndicator2;
	public Material[] cannonMaterials;

	//We know where to spawn the bullets
	public Transform spawner;

	//We know what bullets to spawn. Probably will turn this into an array for all the diff bullets
	public GameObject bullet;

	GameObject player;
	Transform playerT;

	bool container1, container2, container3;
	Color lerped1, lerped2, lerped3, bulletColor1, bulletColor2, bulletColor3;


	//Tried to get this to talk to the ammo container. Currently not working
//	public GameObject ammoContainer;
//	public AmmoHolder theAmmo;
//	int totalAmmo;
	// Use this for initialization

	void Start () {
		soundObject = GameObject.FindGameObjectWithTag ("AudioPlay");
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
		if (container1) {
			lerped1 = Color.Lerp (Color.black, bulletColor1, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator.GetComponent<Renderer> ().material.SetColor ("_Color", lerped1);
		} else {
			lerped1 = Color.Lerp (Color.grey, Color.black, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator.GetComponent<Renderer> ().material.SetColor ("_Color", lerped1);
		}
		if (container2) {
			lerped2 = Color.Lerp (Color.black, bulletColor2, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator1.GetComponent<Renderer> ().material.SetColor ("_Color", lerped2);
		} else {
			lerped2 = Color.Lerp (Color.black, Color.grey, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator1.GetComponent<Renderer> ().material.SetColor ("_Color", lerped2);
		}
		if (container3) {
			lerped3 = Color.Lerp (Color.black, bulletColor3, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator2.GetComponent<Renderer> ().material.SetColor ("_Color", lerped3);
		} else {
			lerped3 = Color.Lerp (Color.grey, Color.black, Mathf.PingPong (Time.time, 1));
			nextAmmoIndicator2.GetComponent<Renderer> ().material.SetColor ("_Color", lerped3);
		}

		if (Input.GetMouseButtonDown (0)) {
			//If you have at enough ammo to shoot...
			if (cannonAmmo.Count > 0) {
				soundObject.GetComponent<AudioScript> ().Shot ();
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

	void FixedUpdate () {
		//ammoCountText.GetComponent<Text> ().text = cannonAmmo.Count.ToString();
	}

	public void textUpdate() {
		//After being fed ammo or shooting bullet, update information for the next ammo type the cannon will shoot
		if (cannonAmmo.Count > 0) {
			nextAmmo = cannonAmmo [0];

			//Based on "next ammo," cannon will change material
			if (nextAmmo == "Red") {
				bulletColor1 = Color.red;
				container1 = true;
				//nextAmmoIndicator.GetComponent<MeshRenderer> ().material = cannonMaterials [0];
			} else if (nextAmmo == "Green") {
				bulletColor1 = Color.green;
				container1 = true;
				//nextAmmoIndicator.GetComponent<MeshRenderer> ().material = cannonMaterials [1];
			} else if (nextAmmo == "Blue") {
				bulletColor1 = Color.blue;
				container1 = true;
				//nextAmmoIndicator.GetComponent<MeshRenderer> ().material = cannonMaterials [2];
			} 
		}
			
		else {
			container1 = false;
			//nextAmmoIndicator.GetComponent<MeshRenderer> ().material = cannonMaterials [3];
		} 

		if (cannonAmmo.Count > 1) {
			string nextAmmo1 = cannonAmmo [1];

			//Based on "next ammo," cannon will change material
			if (nextAmmo1 == "Red") {
				bulletColor2 = Color.red;
				container2 = true;
				//nextAmmoIndicator1.GetComponent<MeshRenderer> ().material = cannonMaterials [0];
			} else if (nextAmmo1 == "Green") {
				bulletColor2 = Color.green;
				container2 = true;
				//nextAmmoIndicator1.GetComponent<MeshRenderer> ().material = cannonMaterials [1];
			} else if (nextAmmo1 == "Blue") {
				bulletColor2 = Color.blue;
				container2 = true;
				//nextAmmoIndicator1.GetComponent<MeshRenderer> ().material = cannonMaterials [2];
			} 
		}

		else {
			container2 = false;
			//nextAmmoIndicator1.GetComponent<MeshRenderer> ().material = cannonMaterials [3];
		} 

		if (cannonAmmo.Count > 2) {
			string nextAmmo2 = cannonAmmo [2];

			//Based on "next ammo," cannon will change material
			if (nextAmmo2 == "Red") {
				bulletColor3 = Color.red;
				container3 = true;
				//nextAmmoIndicator2.GetComponent<MeshRenderer> ().material = cannonMaterials [0];
			} else if (nextAmmo2 == "Green") {
				bulletColor3 = Color.green;
				container3 = true;
				//nextAmmoIndicator2.GetComponent<MeshRenderer> ().material = cannonMaterials [1];
			} else if (nextAmmo2 == "Blue") {
				bulletColor3 = Color.blue;
				container3 = true;
				//nextAmmoIndicator2.GetComponent<MeshRenderer> ().material = cannonMaterials [2];
			} 
		}

		else {
			container3 = false;
			//nextAmmoIndicator2.GetComponent<MeshRenderer> ().material = cannonMaterials [3];
		} 

		//updates UI element with heldAmmo contents!
		//heldAmmoText.GetComponent<Text>().text = "Ammo held:";

//		for (int i = 0; i <= cannonAmmo.Count; i++) {
//			heldAmmoText.GetComponent<Text> ().text += " " + cannonAmmo [i];
//		}
	}
}
