using UnityEngine;
using System.Collections;

//this script deals with the downward movement of the spawned enemies 

public class EnemyMovement : MonoBehaviour {
	public GameObject highlight;
	public GameObject transparent;

	public string enemyIdentity;

	public bool isTutorial;

	public float speed;
	Renderer enemyRend;
	bool isCanonLooking = false;

	void Start () {
		transparent = this.transform.Find ("InvisiVirus").gameObject;
		highlight = this.transform.Find ("Highlight").gameObject;
		enemyRend = GetComponent<Renderer> ();
		speed = 1.5f; //+ PlayerPrefs.GetInt ("enemySpeedBonus"); //speed will increase every level
		if (isTutorial) {
			speed = 0f;
		}
	}

	void Update (){
		//If the Canon is not looking at the object, then set the color of the ennemy to grey.
		if (!isCanonLooking) {
			//enemyRend.material.SetColor ("_Color", Color.grey);
			transparent.SetActive (true);
		} else {
			
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
		if (canon.name == "aim") {
			isCanonLooking = true;
			getColor ();
		}
	}
	void OnTriggerStay( Collider canon){
		if (canon.name == "aim") {
			isCanonLooking = true;
			getColor ();
		}
	}
	void OnTriggerExit( Collider canon){
		if (canon.name == "aim") {
			isCanonLooking = false;
			highlight.SetActive (false);
		}
	}
	void getColor(){
//		if (enemyIdentity == "Red") {
//			enemyRend.material.SetColor ("_Color", Color.red);
//		} else if (enemyIdentity == "Blue") {
//			enemyRend.material.SetColor ("_Color", Color.blue);
//		} else {
//			enemyRend.material.SetColor ("_Color", Color.green);
//		}
		//Debug.Log("blah!");
		highlight.SetActive (true);
		transparent.SetActive (false);
	}

//	void OnTriggerEnter(Collider bullet){
//		
//			if (enemyIdentity != bullet.GetComponent<BulletMove> ().bulletIdentity) {
//				StartCoroutine (MoveBack ());  //move enemy back certain distance
//				Debug.Log("hit wrong enemy!"); 
//
//			}
//			
//			
//	} //v
//
//	IEnumerator MoveBack () {
//
//		yield return new WaitForSeconds (.2f);
//		transform.position += Vector3.forward * 30 * Time.deltaTime; 
//		speed += .3f; //increase speed
//
//	}
}