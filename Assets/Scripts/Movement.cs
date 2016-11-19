using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private Rigidbody rbody;
	public float movespeed;
	public float upwardForce;
	public float forwardForce;
	public bool isGrounded;
	public Transform groundcheck;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
		rbody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle(groundcheck.position, 1f, groundLayer);
		if(Input.GetKey(KeyCode.W)){
			rbody.AddForce(Vector3.forward * movespeed);
		}
		if(Input.GetKey(KeyCode.S)){
			rbody.AddForce(Vector3.back * movespeed);
		}
		if(Input.GetKey(KeyCode.A)){
			rbody.AddForce(Vector3.left * movespeed);
		}
		if(Input.GetKey(KeyCode.D)){
			rbody.AddForce(Vector3.right * movespeed);
		}
		if(Input.GetKey(KeyCode.F)){
			rbody.AddForce (forwardForce, upwardForce, 0, ForceMode.Impulse);
			Debug.Log ("Launched");
		}
	}
}
