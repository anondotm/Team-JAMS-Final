using UnityEngine;
using System.Collections;

public class Follow_Mouse : MonoBehaviour {
	Vector3 mouse_Position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouse_Position = Input.mousePosition;
		mouse_Position.z = 10;
		mouse_Position = Camera.main.ScreenToWorldPoint (mouse_Position);
		transform.position = mouse_Position;
	}
}
