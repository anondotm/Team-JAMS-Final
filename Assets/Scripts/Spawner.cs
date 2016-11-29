using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

//this script manages the endless loop of spawning enemies. It is on the SpawnManager object. 

//TO DO: change so spawning values and enemies change depending on what wave you are on

public class Spawner : MonoBehaviour
{
	//public GameObject hazard;
	//public GameObject hazard2; 
	public Vector3 spawnValues;
	public GameObject [] easyEnemies; 
	public GameObject [] mediumEnemies; 
	public GameObject[] hardEnemies; 

	GameObject[] spawnArray;
	int enemyIndex; 


	public int hazardCount; //how many in each wave
	public float spawnWait; //how many seconds between each enemy 
	public float startWait; //how many seconds before each first enemy appears 
	public float waveWait; //how much between each wave
	public float spawnChanceHard; //if no. generated below this, hard enemy is spawned 
	public float spawnChanceEasy; //if no. generated above this, easy is spawned. medium is for in between them 

	int waveNo = 1; //number of waves passed

	float randomChance; 

	public Text waveNoText; //UI element of wave 

	void Start () {
		
		StartCoroutine (SpawnWaves());
		SetWaveNumber (); 


	}//end of start 

	void Update () {

		randomChance = Random.Range (0f, 1f);

		if (waveNo > 5 && waveNo < 10) {

			spawnChanceHard = .20f; 
			spawnChanceEasy = .50f; 

		} else if (waveNo > 10) {

			spawnChanceHard = .45f; 
			spawnChanceEasy = .75f; 

		} //end of else if

		if(Input.GetKeyDown(KeyCode.T)){

			TestingNumbers (); 
		}

	} //end of update 


	void TestingNumbers() { //PRESS T to see the spawn chances of hard and easy enemies 

		Debug.Log("spawnChanceHard = " + spawnChanceHard); 
		Debug.Log ("spawnChanceEasy = " + spawnChanceEasy); 

	} //end of void testingnumbers 
		


	IEnumerator SpawnWaves () { //actual coroutine that spawns the enemies
		yield return new WaitForSeconds (startWait); //startWait is how many seconds before first enemy appears 
		while (true) {

			for (int i = 0; i < hazardCount; i++) {

				Debug.Log (randomChance); 

				if (randomChance > spawnChanceEasy) {

					spawnArray = easyEnemies;

				}
				else if (randomChance < spawnChanceHard) {

					spawnArray = hardEnemies;

				} else {

					spawnArray = mediumEnemies; 

				} //end of else
					
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z); //spawn between set values
				Quaternion spawnRotation = Quaternion.identity; 

				enemyIndex = Random.Range (0, spawnArray.Length);
				//Instantiate (mediumEnemies[UnityEngine.Random.Range(0, mediumEnemies.Length - 1)], spawnPosition, spawnRotation); //instantiate enemy
				Instantiate (spawnArray [enemyIndex], spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);

			} //end of for in i = 0 


			yield return new WaitForSeconds (waveWait); //start next wave of enemies 

			waveNo++; 

			//randomChance = Random.Range (0f, 1f); 

			SetWaveNumber (); 

			}// end of while true
		} // end of SpawnWaves 


	void SetWaveNumber () {

		waveNoText.text = "WAVE " + waveNo.ToString (); 

	}
}