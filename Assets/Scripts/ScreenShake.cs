using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	//checks if the camera should currently be shaking.
	bool shouldShake = false;
	//Keeps track of the camera's starting position
	Vector3 startPosition;
	//Checks if the camera is currently shaking
	bool isCurrentlyShaking = false;
	//How long should the shake last
	public float howLongIsShake = 1f;
	// Use this for initialization
	void Start () {
		//Define the start position of the camera
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

		//If the player presses space and the camera is not currently shaking.
		/*if (Input.GetKeyDown (KeyCode.Space) && !isCurrentlyShaking) {
			//Start the coroutine that will enable the shaking
			StartCoroutine (ShakeCam ());
			//Checkes if the player pressed space for debug purposes.
			Debug.Log ("The player pressed Space");

		} */
		//If the camera should be shaking then shake it.
		if (shouldShake) {			
			Vector3 shakeSideDirection = transform.right * Mathf.Sin (Time.time * 40f) * 0.04f;
			Vector3 shakeUpDirection = transform.up * Mathf.Sin (Time.time * 36f) * 0.04f;
			transform.position += shakeSideDirection + shakeUpDirection;
		}
		else {
			//resets the camera to its original position
			transform.position = startPosition;
		}//else {
		//transform.position = startPosition;
		//}
	}
	public IEnumerator ShakeCam(){
		//the player should not be able to press space again.
		isCurrentlyShaking = true;
		//the camera should be shaking
		shouldShake = true;
		//We wait a certain amount of time while the shake is happening
		yield return new WaitForSeconds (howLongIsShake);
		//Stop the shake
		shouldShake = false;
		//The player can press space again.
		isCurrentlyShaking = false;


	}
}
