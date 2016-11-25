using UnityEngine;
using System.Collections;

public class Accelerate : MonoBehaviour {

	public string enemyIdentity;
	public float accelSpeed;

	void Start () {
	 
	}

	// Update is called once per frame
	void FixedUpdate () {

		goToPlayer(); //call function 
		accelSpeed += .1f; 

	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward * accelSpeed * Time.deltaTime;
	}
}
