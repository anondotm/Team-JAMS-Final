using UnityEngine;
using System.Collections;

public class IgnoreBulletCollision : MonoBehaviour {
	public GameObject CanonSight;
	// Use this for initialization
	void Start () {
		CanonSight = GameObject.FindGameObjectWithTag ("aim");
		Physics.IgnoreCollision (CanonSight.GetComponent<Collider> (), GetComponent<Collider> ());
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
