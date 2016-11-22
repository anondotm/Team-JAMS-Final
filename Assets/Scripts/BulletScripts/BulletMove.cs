using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	//Each bullet has a rigidbody to add velocity/for it to move
	private Rigidbody bulletRigidBody;
	//Define the speed at which the bullet will move
	public int moveSpeedBullet;
	// Use this for initialization
	void Start () {
		//We get the rigidbody
		bulletRigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//We apply the velocity to the rigidbody based on our move speed
		bulletRigidBody.velocity = (this.transform.forward * moveSpeedBullet)*Time.deltaTime;  
	}

	void OnTriggerEnter( Collider enemy){
		//Destroy the bullet and enemy if they collide. ENEMY NEEDS TO BE TRIGGER!!!!!!
		if (enemy.tag == "enemy") {
			Destroy (enemy.gameObject);
			Destroy (gameObject);
		}
	}
}
