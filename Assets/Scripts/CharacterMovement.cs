using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float playerSpeed;
	CharacterController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (Input.GetKey (KeyCode.W)) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		else if (Input.GetKey (KeyCode.S)) {
			transform.eulerAngles = new Vector3 (0, -180, 0);

		}
		else if (Input.GetKey (KeyCode.A)) {
			transform.eulerAngles = new Vector3 (0, -90, 0);

		}
		else if (Input.GetKey (KeyCode.D)) {
			transform.eulerAngles = new Vector3 (0, 90, 0);
		}



		playerController.SimpleMove (new Vector3(inputX,0,inputY) * playerSpeed);

	}
}
