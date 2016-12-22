using UnityEngine;
using System.Collections;

public class MoveBack : MonoBehaviour {

	public string enemyIdentity; 
	//public AudioSource wrongEnemy; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider bullet){
		if (bullet.tag == "Ammo1") {

			if (enemyIdentity != bullet.GetComponent<BulletMove> ().bulletIdentity) {
				StartCoroutine (WrongBullet ());  //move enemy back certain distance
				Debug.Log ("hit wrong enemy!"); 

			}
		}


	} //v

	IEnumerator WrongBullet () {

		yield return new WaitForSeconds (.1f);
		transform.position += Vector3.forward * 100 * Time.deltaTime; 
		this.gameObject.GetComponent<EnemyMovement> ().speed += .4f; 
		//wrongEnemy.Play (); 

	}
}
