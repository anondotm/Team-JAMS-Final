using UnityEngine;
using System.Collections;

public class IgnoreBulletCollision : MonoBehaviour {
	//This is not the best code but it works for now.
	//Variable that will represent the object with the colider which is the canon sight
	public GameObject CanonSight;
	// Use this for initialization
	void Start () {
		//Associate the canon sight to the actual game object
		CanonSight = GameObject.FindGameObjectWithTag ("aim");
		//Ignore the collision between the canon sight and the bullets.
		Physics.IgnoreCollision (CanonSight.GetComponent<Collider> (), GetComponent<Collider> ());
		
	}

}
