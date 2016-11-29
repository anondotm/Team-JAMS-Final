using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (Blink ()); 
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	IEnumerator Blink () {

		for (int x = 0; x < 5; x++) {

			yield return new WaitForSeconds (2); 

			this.gameObject.GetComponent<Renderer>().enabled = false;

			yield return new WaitForSeconds (2); 

			this.gameObject.GetComponent<Renderer>().enabled = true;

		}
	}
}
