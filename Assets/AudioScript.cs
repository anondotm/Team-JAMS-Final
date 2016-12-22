using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
	public AudioSource EnemyHitSource;
	public AudioSource WrongEnemyHitSource;
	public AudioSource ShotSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnemyHit() {
		EnemyHitSource.Play ();
	}

	public void WrongEnemyHit() {
		WrongEnemyHitSource.Play ();
	}

	public void Shot(){
		ShotSource.Play ();
	}
}
