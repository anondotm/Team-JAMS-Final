using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	//Reference for the UI on the top screen (Player 1)
	public GameObject topScreenUI;

	//Reference for the UI on the bottom screen (Player 2)
	public GameObject botScreenUI;

	//Reference for the different target objects in the tutorial
	public GameObject firstTarget;
	public GameObject secondTarget;
	public GameObject thirdTarget;
	public GameObject fourthTarget;

	//Private integer for a for loop later in the script
	private int i = 0;

	//Starts the Coroutine
	void Start () {
		StartCoroutine (TutorialCoroutine());
	}


	void Update () {
	
	}

	//Start of Coroutine
	IEnumerator TutorialCoroutine() {

		//Modifies top screen UI to welcome players to the game
		topScreenUI.GetComponent<Text> ().text = "Welcome to our game! There's a red enemy out there, \nshoot it down with the LEFT MOUSE BUTTON";

		//Waits for Player 1 to click the left mouse button
		while (Input.GetMouseButtonDown (0) == false) {
			yield return 0;
		}
			
		topScreenUI.GetComponent<Text> ().text = "Seems you don't have any ammo to shoot them with. \nBetter load some up from the deck.";

		yield return new WaitForSeconds (3.0f);

		//Deletes top screen text, so both players can focus on the text about to appear on the bottom screen
		topScreenUI.GetComponent<Text> ().text = null;

		//Inserts text for Player 2's screen
		botScreenUI.GetComponent<Text> ().text = "Okay deck, we need one red ammo for the cannon. \nHead to the RED block and press SPACE to pick one up.";

		//Waits for Player 2 to press Space
		while (Input.GetKeyDown(KeyCode.Space) == false) {
			yield return 0;
		}

		//Waits one frame to turn Input.GetKeyDown(KeyCode.Space) back to false
		yield return 0;

		botScreenUI.GetComponent<Text>().text = "Nice! Okay, now go and \nload it into the cannon with SPACE!";

		//Waits for Player 2 to press Space
		while (Input.GetKeyDown(KeyCode.Space) == false) {
			yield return 0;
		}
		botScreenUI.GetComponent<Text> ().text = null;
		topScreenUI.GetComponent<Text>().text = "Alright! With the right ammo loaded, try and \nshoot down that enemy! If you miss, \njust have the deck load another RED ammo!";

		//Pauses the tutorial until the 1st enemy has been defeated
		while (firstTarget != null){
			yield return 0;
		}
		topScreenUI.GetComponent<Text> ().text = "Nice shot! Okay, now let's ramp up the difficulty a little bit...";

		//When the first enemy has been defeated, turn on the MeshRenderers for the remaining 3 enemies, with pauses in between, and breaks out
		while (firstTarget == null) {
			yield return new WaitForSeconds (1.0f);
			secondTarget.GetComponent<MeshRenderer> ().enabled = true;
			yield return new WaitForSeconds (0.5f);
			thirdTarget.GetComponent<MeshRenderer> ().enabled = true;
			yield return new WaitForSeconds (0.5f);
			fourthTarget.GetComponent<MeshRenderer> ().enabled = true;
			break;
		}
		topScreenUI.GetComponent<Text> ().text = "Whoa! Three enemies! Okay deck, \nload the right ammo quick!";
		yield return new WaitForSeconds (3.0f);
		topScreenUI.GetComponent<Text> ().text = null;
		botScreenUI.GetComponent<Text> ().text = "Make sure to load the ammo in the right order! \nYou need 1 of each color!";

		//Waits for the Player 2 to press Space 4 times (3 times to load the appropriate ammo, 1 time to load it to the cannon)
		//Here is where private integer is used
		while (i <= 3) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				i++;
			}
			yield return 0;
		}
		botScreenUI.GetComponent<Text> ().text = null;
		topScreenUI.GetComponent<Text> ().text = "Hopefully you have the right ammo! Shoot 'em down!";

		//Waits for all 3 of the remaining enemies to be defeated
		while ((secondTarget != null) || (thirdTarget != null) || (fourthTarget != null)) {
			yield return 0;
		}
		topScreenUI.GetComponent<Text> ().text = "Nice! You're ready for the real thing. \nBe wary though, the enemies won't wait " +
		"for you this time. \nYou'll need to communicate with your partner to survive.";
		yield return new WaitForSeconds (7.0f);
		topScreenUI.GetComponent<Text> ().text = "Good luck!";
		botScreenUI.GetComponent<Text> ().text = "Good luck!";
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("CurrentWorkingScene");
	}
}
