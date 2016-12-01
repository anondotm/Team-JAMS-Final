using UnityEngine;
using System.Collections;

public class Accelerate : MonoBehaviour {

	public string enemyIdentity;
	Renderer enemyRend; 
	bool isCanonLooking = false; 
	public float accelSpeed; 

	// Update is called once per frame

	void Start () {
		enemyRend = GetComponent<Renderer> ();
		accelSpeed = 1.4f; //+ PlayerPrefs.GetInt ("enemySpeedBonus"); //speed will increase every level
	}

	void Update (){
		//If the Canon is not looking at the object, then set the color of the ennemy to grey.
		if (!isCanonLooking) {
			enemyRend.material.SetColor ("_Color", Color.grey);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		goToPlayer(); //call function 
		accelSpeed += .01f; 
	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *accelSpeed* Time.deltaTime;
	}

	void OnTriggerEnter( Collider canon){
		isCanonLooking = true;
		getColor ();
	}
	void OnTriggerStay( Collider canon){
		isCanonLooking = true;
		getColor ();
	}
	void OnTriggerExit( Collider canon){
		isCanonLooking = false;
	}
	void getColor(){
		if (enemyIdentity == "Red") {
			enemyRend.material.SetColor ("_Color", Color.red);
		} else if (enemyIdentity == "Blue") {
			enemyRend.material.SetColor ("_Color", Color.blue);
		} else {
			enemyRend.material.SetColor ("_Color", Color.green);
		}
	}
}
