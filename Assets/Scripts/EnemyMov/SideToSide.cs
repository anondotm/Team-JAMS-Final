using UnityEngine;
using System.Collections;

public class SideToSide : MonoBehaviour {

	public float movSpeed; //speed of going forward
	public float frequency; //how fast the side to side speed is
	public float magnitude; //how far to the side the object goes
	private Vector3 axis; 

	public string enemyIdentity;

	private Vector3 pos; 

	void Start () {

		pos = transform.position; 
		axis = transform.right; 


	}

	void Update () {

		pos += transform.forward * Time.deltaTime * movSpeed; 
		transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude; 

	}

}
