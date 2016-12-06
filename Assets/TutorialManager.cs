using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	public GameObject topScreenUI;
	public GameObject botScreenUI;
	public GameObject firstTarget;
	public GameObject secondTarget;
	public GameObject thirdTarget;
	public GameObject fourthTarget;
	// Use this for initialization
	void Start () {
		StartCoroutine (TutorialCoroutine());
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TutorialCoroutine() {
		topScreenUI.GetComponent<Text> ().text = "Welcome to our game! There's a red enemy out there, \nshoot it down with the LEFT MOUSE BUTTON`";
		while (Input.GetMouseButtonDown (0) == false) {
			yield return 0;
		}
		topScreenUI.GetComponent<Text> ().text = "Seems you don't have any ammo to shoot them with. \nBetter load some up from the deck.";
		yield return new WaitForSeconds (3.0f);
		topScreenUI.GetComponent<Text> ().text = null;
		botScreenUI.GetComponent<Text> ().text = "Okay deck, we need one red ammo for the cannon. \nHead to the RED block and press SPACE to pick one up.";
		while (Input.GetKeyDown(KeyCode.Space) == false) {
			yield return 0;
		}
		Debug.Log ("picked up");
		botScreenUI.GetComponent<Text>().text = "Nice! Okay, now go and \nload it into the cannon with SPACE!";
		while (Input.GetKeyDown(KeyCode.Space) == false) {
			yield return 0;
		}
		botScreenUI.GetComponent<Text> ().text = null;
		topScreenUI.GetComponent<Text>().text = "Alright! With the right ammo loaded, try and \nshoot down that enemy! If you miss, \njust have the deck load another RED ammo!";
		while (firstTarget != null){
			yield return 0;
		}
		topScreenUI.GetComponent<Text> ().text = "Nice shot! Okay, now let's ramp up the difficulty a little bit...";
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
		yield return new WaitForSeconds (1.0f);
		topScreenUI.GetComponent<Text> ().text = null;
		botScreenUI.GetComponent<Text> ().text = "Make sure to load the ammo in the right order! \nYou need 1 of each color!";
		for (int i = 0; i >= 4; i++) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				i++;
			} else {
				yield return 0;
			}
		}
		botScreenUI.GetComponent<Text> ().text = null;
		topScreenUI.GetComponent<Text> ().text = "Hopefully you have the right ammo! Shoot 'em down!";
		while (secondTarget != null && thirdTarget != null && fourthTarget != null) {
			yield return 0;
		}
		topScreenUI.GetComponent<Text> ().text = "Nice! You got them all! I think you're ready to move on to the real challenge. Be wary though, the enemies won't be standing" +
		"still this time. You'll need to communicate with your partner to survive.";
		yield return new WaitForSeconds (1.0f);
		topScreenUI.GetComponent<Text> ().text = "Good luck!";
		botScreenUI.GetComponent<Text> ().text = "Good luck!";
		


	}
}
