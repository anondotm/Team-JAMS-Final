using UnityEngine;
using System.Collections;

public class AmmoStackScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Stack Trigger") {
			gameObject.transform.parent = player.transform;
		}
	}
}
