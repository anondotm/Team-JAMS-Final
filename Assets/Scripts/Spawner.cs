﻿using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

//this script manages the endless loop of spawning enemies. It is on the Spawner object. 

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
	public float startWait; //how many seconds before each first enemy appears (only at very beginning) 
	public float waveWait; //how many seconds between each wave
	float spawnChanceHard; //if no. generated below this, hard enemy is spawned 
	float spawnChanceEasy; //if no. generated above this, easy is spawned. medium is for in between them 

	int waveNo = 1; //number of waves passed

	float randomChance; 

	public Text waveNoText; //UI element of wave 

	void Start () {
		
		StartCoroutine (SpawnWaves());
		SetWaveNumber (); 

		spawnChanceHard = .00f; 
		spawnChanceEasy = .05f; 
		spawnWait = 4; 


	}//end of start 

	void Update () {

		randomChance = Random.Range (0f, 1f);

		if (waveNo > 3 && waveNo < 5) { //difficulty up 

			spawnChanceHard = .05f; 
			spawnChanceEasy = .33f; 
			 

		} else if (waveNo > 6 && waveNo < 8) {
			
			spawnChanceEasy = .60f; 
			hazardCount = 4;  
			spawnWait = 3; 

		} else if (waveNo > 8 && waveNo < 10) {

			spawnChanceHard = .10f;
			spawnChanceEasy = .65f; 
			hazardCount = 5; 

		} else if (waveNo > 11 && waveNo < 30) {

			spawnChanceHard = .15f;
			spawnChanceEasy = .65f; 


		} else if (waveNo > 30) {

			spawnChanceHard = .33f;
			spawnChanceEasy = .80f; 


		}

		if(Input.GetKeyDown(KeyCode.T)){ //see the spawn values for testing purposes 

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
				
				// ROBERT: spawnWait should be affected by your waveNo and pacing?
				// it's also one of the main determinants of game difficulty?
				// you might do something like: WaitForSeconds( Mathf.Clamp(spawnWait - waveNo, minimumSpawnTime, maxSpawnTime) )
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
