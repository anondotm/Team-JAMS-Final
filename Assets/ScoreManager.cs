using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	//this script manages the Highscore of the player 
 
	public int score = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText.text = "SCORE: 0";

	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.P)){

			score++; 
		
			Debug.Log ("score added!"); 
			scoreUpdate (1); 
		}
	
	}

	public void scoreUpdate(int added){
		
		score += added;
		scoreText.text = "SCORE: " + score.ToString ();

		PlayerPrefs.SetInt ("PlayerScore", score); 

		if (PlayerPrefs.HasKey ("HighScore")) {

			if (score > PlayerPrefs.GetInt ("HighScore")) {

				PlayerPrefs.SetInt ("HighScore", score); 

			} 

		} else {

			PlayerPrefs.SetInt("HighScore", score); 

		}

	}
}
