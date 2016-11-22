using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	int score = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText.text = "SCORE: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void scoreUpdate(int added){
		score += added;
		scoreText.text = "SCORE: " + score.ToString ();
	}
}
