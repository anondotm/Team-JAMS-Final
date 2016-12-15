using UnityEngine;
using System.Collections;

public class MoveBack : MonoBehaviour {

	public string enemyIdentity; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider bullet){

		if (enemyIdentity != bullet.GetComponent<BulletMove> ().bulletIdentity) {
			StartCoroutine (WrongBullet ());  //move enemy back certain distance
			Debug.Log("hit wrong enemy!"); 

		}


	} //v

	IEnumerator WrongBullet () {

		yield return new WaitForSeconds (.4f);
		transform.position += Vector3.forward * 100 * Time.deltaTime; 
		this.gameObject.GetComponent<EnemyMovement> ().speed += .4f; 

	}
}
