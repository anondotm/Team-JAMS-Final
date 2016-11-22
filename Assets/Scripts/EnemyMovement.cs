using UnityEngine;
using System.Collections;

//this script deals with the downward movement of the spawned enemies 

public class EnemyMovement : MonoBehaviour {
	public string enemyIdentity;

	public float speed;

	void Start () {

		speed = 1.5f; //+ PlayerPrefs.GetInt ("enemySpeedBonus"); //speed will increase every level
	}

	// Update is called once per frame
	void FixedUpdate () {

		goToPlayer(); //call function 

	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *speed* Time.deltaTime;
	}
}