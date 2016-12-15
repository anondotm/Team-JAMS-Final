using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOverMenu : MonoBehaviour {

	public Canvas GameOver; 
	public Button PlayAgain; 
	public Button QuitButton; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToPlayScene() {

		SceneManager.LoadScene ("CurrentWorkingScene"); 

	}

	public void GoToTitle() {

		SceneManager.LoadScene ("Title"); 

	}

}
