using UnityEngine;
using System.Collections;

public class EnemyIdentityScript : MonoBehaviour {
	public string enemyIdentity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void freezeRoutine(){
		transform.Translate (0, 0, 1);
	}
}
