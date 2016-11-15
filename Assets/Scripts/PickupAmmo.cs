using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupAmmo : MonoBehaviour {
	public List<int> heldAmmo = new List<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ammoCheckRay = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast(ammoCheckRay,.5f, out hit, 2f)){
			Debug.Log ("There's something there...");

			if (Input.GetKeyDown (KeyCode.Space)) {
				if (hit.collider.tag == "Ammo1") {
					heldAmmo.Add (1);
				} else if (hit.collider.tag == "Ammo2") {
					heldAmmo.Add (2);
				} else if (hit.collider.tag == "Ammo3") {
					heldAmmo.Add (3);
				} else if (hit.collider.tag == "Trash") {
					heldAmmo.Clear ();
				} else if (hit.collider.tag == "DumbWaiter") {
					hit.collider.GetComponent<AmmoHolder> ().heldAmmo = new List<int> (heldAmmo);
				}
			}

		}
	}

	void FixedUpdate () {
		
	}
}
