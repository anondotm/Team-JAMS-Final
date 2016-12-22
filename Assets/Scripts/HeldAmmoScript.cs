using UnityEngine;
using System.Collections;

public class HeldAmmoScript : MonoBehaviour {
	bool destroyed;
	// Use this for initialization
	void Start () {
		destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			StartCoroutine ("MoveCoroutine");
		}
	
	}

	void FixedUpdate () {
		if (destroyed == true) {
			Destroy (this.gameObject);
		}
	}

	public IEnumerator MoveCoroutine() {
		float t = 0f;
		float endT = Random.Range (.75f, 1f);
		Vector3 startPosition = transform.position;
		Vector3 endPosition = startPosition + new Vector3 (0, 10, 0);

		while (t < endT) {
			t += Time.deltaTime;
			transform.position = Vector3.Lerp (startPosition, endPosition, t);
			yield return 0;
		}


		destroyed = true;
		yield return 0;

	}
}
