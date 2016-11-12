using UnityEngine;
using System.Collections;

public class DestroyMyself : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecomeInvisible () {

		gameObject.SetActive (false); 

	}
}
