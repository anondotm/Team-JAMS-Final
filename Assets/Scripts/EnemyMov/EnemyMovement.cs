using UnityEngine;
using System.Collections;

//this script deals with the downward movement of the spawned enemies 

public class EnemyMovement : MonoBehaviour {
	public string enemyIdentity;
	public float speed;
	Renderer enemyRend;
	bool isCanonLooking = false;

	void Start () {
		enemyRend = GetComponent<Renderer> ();

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
	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *speed* Time.deltaTime;
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