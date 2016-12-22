using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public GameObject soundObject;
	//The "identity" of this bullet (color for now). Use this to check if identity matches for enemies, if you can destroy
	public string bulletIdentity;
	//Each bullet has a rigidbody to add velocity/for it to move
	private Rigidbody bulletRigidBody;
	//Define the speed at which the bullet will move
	public int moveSpeedBullet;

	//Scoremanager object to update whenever enemy is hit!
	public GameObject GameManager;

	public GameObject particle_explosion;

	// Use this for initialization
	void Start () {
		//We get the rigidbody
		GameManager = GameObject.FindGameObjectWithTag ("gameManagertag"); 
		soundObject = GameObject.FindGameObjectWithTag ("AudioPlay");
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
			Debug.Log ("This hit an ennemy");
			if (bulletIdentity == enemy.GetComponent<EnemyIdentityScript> ().enemyIdentity) {
				Debug.Log ("But did it destroy it");
				//soundObject.GetComponent<AudioScript> ().EnemyHit ();
				Instantiate (particle_explosion, transform.position, Quaternion.identity);
				Destroy (enemy.gameObject);
				GameManager.GetComponent<ScoreManager> ().scoreUpdate (1);
				Debug.Log ("You hit an enemy!");
			} else {
				//soundObject.GetComponent<AudioScript> ().WrongEnemyHit ();
				//enemy.GetComponent<EnemyIdentityScript> ().freezeRoutine ();
			}
			Destroy (gameObject);
		}

		else if (enemy.tag == "Bullet Wall") {
			Destroy (gameObject);
		}
	}
}
