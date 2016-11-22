using UnityEngine;
using System.Collections;

public class DestroyMyself : MonoBehaviour {

	HealthManager healthmanager; 
	public GameObject gameManager; 

	// Use this for initialization
	void Start () {

		gameManager = GameObject.FindGameObjectWithTag ("gameManagertag"); 
		healthmanager = gameManager.GetComponent<HealthManager> (); 

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){

			Destruction (); 
			Debug.Log ("this object is destroyed via keypress!"); 

		}
	
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "wall") {
			Debug.Log ("destruction via collision!"); 
			Destruction (); 
		}

	}

	void killMyself() {

		if (transform.position.z >= 24) {
			Debug.Log("destruction via position");
			Destruction (); 

		}

	}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "enemy") {
			Debug.Log ("triggered");
			Destruction (); 

		}

	}

	void OnBecameInvisible() {

		Debug.Log ("destruction via invisibility"); 
		Destruction (); 
	}


	void Destruction () {

		healthmanager.SetHealth (1); 
		healthmanager.SetHealthText (); 
		Destroy (this.gameObject); 
		Debug.Log ("gone!"); 
	}
}
