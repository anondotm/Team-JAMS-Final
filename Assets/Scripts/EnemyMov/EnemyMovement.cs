using UnityEngine;
using System.Collections;

//this script deals with movement of the spawned enemies 

public class EnemyMovement : MonoBehaviour {

	public string enemyIdentity;
	public float speed;

	void Start () {


	}

	// Update is called once per frame
	void FixedUpdate () {

		goToPlayer(); //call function 

	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *speed* Time.deltaTime;
	}
}