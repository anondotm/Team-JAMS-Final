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

	public void tookAmmo () {
		Destroy(ammoContained [ammoContained.Count - 1]);
		ammoContained.RemoveAt (ammoContained.Count -1);
		StartCoroutine (replaceAmmo(ammoContained.Count));
	}

	public IEnumerator replaceAmmo(int value){
		Debug.Log ("success");
		float startTime = Time.time;
		while (Time.time < (startTime + 1)) {
			yield return 0;
		}
		//Debug.Log ("Time has passed.");
		GameObject newAmmo = (GameObject) Instantiate (physicalType, ammoPosition [value].position, Quaternion.identity);
		ammoContained.Add (newAmmo);
		yield return 0;
	}
}
