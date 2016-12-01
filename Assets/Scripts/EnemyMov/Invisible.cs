using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	public string enemyIdentity;
	Renderer enemyRend; 
	public float speed; 
	bool isCanonLooking = false; 


	// Use this for initialization

	
	// Update is called once per frame
	void Start () {
		
		enemyRend = GetComponent<Renderer> ();
		StartCoroutine (Blink ()); 
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

	IEnumerator Blink () {

		for (int x = 0; x < 5; x++) {

			yield return new WaitForSeconds (1); 

			this.gameObject.GetComponent<Renderer>().enabled = false;

			yield return new WaitForSeconds (1); 

			this.gameObject.GetComponent<Renderer>().enabled = true;

		}
	}
}
