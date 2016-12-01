using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	public Text HighScore; 

	// Use this for initialization
	void Start () {

		ShowHighScore (); 

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.T)){

			Debug.Log(PlayerPrefs.GetInt("HighScore")); 
		}
	}

	void ShowHighScore () {


		HighScore.text = "You eliminated " + PlayerPrefs.GetInt ("HighScore").ToString () + " viruses!"; //highest score is taken 

	}


	public void BackToTitle () { //press this button to go back to Title Screen 

		SceneManager.LoadScene ("Title"); 

	}
}
