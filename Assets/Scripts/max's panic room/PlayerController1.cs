using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController1 : MonoBehaviour {



	//List used to "hold" ammo for the cannon
	public List<string> cannonAmmo = new List<string>();

	//Variable used to access the character controller (what we will use to make the player character move).
	//CharacterController cController;
	//Determines how hign and low the player character can look
	public int playerVisionMinX = -50;
	public int playerVisionMaxX = 65;
	public int playerVisionMinY = -100;
	public int playerVisionMaxY = 100;
	//This value will increase or decrease the mouse sensitivity.
	//To decrease it pick a number between 0-1, to increase it pick any other positive number.
	// Picking 1 will keep the mouse on it's default sensitivity (though picking really big numbers might be bad...).
	public float mouse_Sensitivity = 1f;
	//Vector 3 used to keep track of where the character is currently looking
	Vector3 euler;
	bool canMove = true;


	// Use this for initialization
	void Start () {
		//Initialize the character controller from the player character
		//cController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		//First we lock the mouse into the screen
		Screen.lockCursor = true;
		//TODO: Consider adding the possibility for the player to unlock the mouse from the screen; and then back again
		if (canMove) {
			//Create all the variables that will keep track of player movement/location
			//float inputX = Input.GetAxis ("Horizontal");
			//float inputY = Input.GetAxis ("Vertical");
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");
			//Move the character forwards and back
			//cController.SimpleMove (transform.forward * inputY * 5f);
			//and left and right.
			//cController.SimpleMove (transform.right * inputX * 5f);
			//assign the rotation angles of the camera object
			Camera.main.transform.localEulerAngles = euler;
			//have the angle that rotates the camera up and down be subject to the mouse movement.

			euler.x -= mouseY * mouse_Sensitivity;

			//Camera.main.transform.Rotate(-mouseY,0f,0f);
			//Rotates the player object left and right through the use of the mouse (look left and right).
			euler.y += mouseX * mouse_Sensitivity;

			//checks if the rotation angle exceeds the max and min allowed
			if (euler.x >= playerVisionMaxX) {
				//If so then the angle is locked between the max and min values.
				euler.x = Mathf.Clamp (euler.x, playerVisionMinX, playerVisionMaxX);
			}
			//The same is done here but for the min values.
			if (euler.x <= playerVisionMinX) {
				euler.x = Mathf.Clamp (euler.x, playerVisionMinX, playerVisionMaxX);
			}
			if (euler.y >= playerVisionMaxY) {
				//If so then the angle is locked between the max and min values.
				euler.y = Mathf.Clamp (euler.y, playerVisionMinY, playerVisionMaxY);

			}
			//The same is done here but for the min values.
			if (euler.y <= playerVisionMinY) {
				euler.y = Mathf.Clamp (euler.y, playerVisionMinY, playerVisionMaxY);
			}
		}
	}

	public bool getCanMove(){
		return canMove;
	}
	public void setCanMove(bool activator){
		canMove = activator;
	}


	//activated by "AmmoHolder" script on cannon repo, the cannon receives 
	public void receiveAmmo(){

	}

}
