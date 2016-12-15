using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoSource : MonoBehaviour {
	public GameObject physicalType;
	public List<Transform> ammoPosition;
	public List<GameObject> ammoContained;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void tookAmmo () {
		ammoContained [ammoContained.Count - 1];
		StartCoroutine ("replaceAmmo", ammoContained.Count-1);
	}

	public IEnumerator replaceAmmo(int value){
		float startTime = Time.time;
		if (Time.time > (startTime + 1)) {
			Instantiate (physicalType, ammoPosition [value], Quaternion.identity);
		}
	}
}
