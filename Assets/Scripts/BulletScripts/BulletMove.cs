using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	//The "identity" of this bullet (color for now). Use this to check if identity matches for enemies, if you can destroy
	public string bulletIdentity;
	//Each bullet has a rigidbody to add velocity/for it to move
	private Rigidbody bulletRigidBody;
	//Define the speed at which the bullet will move
	public int moveSpeedBullet;

	//Scoremanager object to update whenever enemy is hit!
	public GameObject GameManager;

	// Use this for initialization
	void Start () {
		//We get the rigidbody
		GameManager = GameObject.FindGameObjectWithTag ("gameManagertag"); 
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
			if (bulletIdentity == enemy.GetComponent<EnemyMovement> ().enemyIdentity) {
				Destroy (enemy.gameObject);
				GameManager.GetComponent<ScoreManager> ().scoreUpdate (1);
			}
			Destroy (gameObject);
		}

		else if (enemy.tag == "Bullet Wall") {
			Destroy (gameObject);
		}
	}
}
