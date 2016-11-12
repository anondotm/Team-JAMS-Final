using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

//this script manages the endless loop of spawning enemies. It is on the SpawnManager object. 

public class Spawner : MonoBehaviour
{
	//public GameObject hazard;
	//public GameObject hazard2; 
	public Vector3 spawnValues;
	public GameObject [] enemies; 

	public int hazardCount; //how many in each wave
	public float spawnWait; //how many seconds between each enemy 
	public float startWait; //how many seconds before each first enemy appears 
	public float waveWait; //how much between each wave


	//public Text countTextObject; 
	//public static Spawner spawnerInstance; 
	//public int count = 0; 

	void Start ()
	{
		//spawnerInstance = this;
		StartCoroutine (SpawnWaves ());
	}

	void Update () {

	}

	IEnumerator SpawnWaves () //actual thing that spawns the enemies
	{
		yield return new WaitForSeconds (startWait); //startWait is how many seconds before first enemy appears 
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y,spawnValues.y), spawnValues.z); //spawn between set values
				Quaternion spawnRotation = Quaternion.identity; 

				Instantiate (enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPosition, spawnRotation); //instantiate enemy

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait); //start next wave of enemies 
		}
	}		
}