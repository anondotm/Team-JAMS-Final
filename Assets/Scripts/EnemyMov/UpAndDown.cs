using UnityEngine;
using System.Collections;

public class UpAndDown : MonoBehaviour {

	// Use this for initialization
	public float movSpeed; //normal forward speed
	public float frequency; //speed of the up/down movement
	public float magnitude; //how high/low the object goes 
	private Vector3 axis; 

	public string enemyIdentity;

	private Vector3 pos; 

	void Start () {

		pos = transform.position; 
		axis = transform.up; 


	}

	void Update () {

		pos += transform.forward * Time.deltaTime * movSpeed; 
		transform.position = pos + axis * Mathf.Cos (Time.time * frequency) * magnitude; 

	}

}
