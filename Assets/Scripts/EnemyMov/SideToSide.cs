using UnityEngine;
using System.Collections;

public class SideToSide : MonoBehaviour {

	public string enemyIdentity;
	Renderer enemyRend; 
	public float speed; 
	bool isCanonLooking = false; 


	public float movSpeed; //speed of going forward
	public float frequency; //how fast the side to side speed is
	public float magnitude; //how far to the side the object goes
	private Vector3 axis; 


	private Vector3 pos; 

	void Start () {

		pos = transform.position; 
		axis = transform.right; 
		enemyRend = GetComponent<Renderer> ();
	
	}

	void Update (){
		//If the Canon is not looking at the object, then set the color of the ennemy to grey.
		if (!isCanonLooking) {
			enemyRend.material.SetColor ("_Color", Color.grey);
		}

			pos -= transform.forward * Time.deltaTime * movSpeed; 
			transform.position = pos + axis * Mathf.Cos (Time.time * frequency) * magnitude; 

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
