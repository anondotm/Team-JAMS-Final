using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float playerSpeed;
	CharacterController playerController;

	float inputX;
	float inputY;

	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");

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

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			StartCoroutine ("dash");
		}

		playerController.SimpleMove (new Vector3(inputX,0,inputY) * playerSpeed * Time.deltaTime * 70);

	}

	public IEnumerator dash () {
		float startTime = Time.time;
		float startSpeed = 2.5f;
		while (Time.time < (startTime + .175f)) {
			playerController.SimpleMove(new Vector3 (inputX,0,inputY) * (playerSpeed*startSpeed));
			startSpeed *= .9f;
			yield return 0;
		}
	}
}
