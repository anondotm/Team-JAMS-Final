using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	public string enemyIdentity;
	Renderer enemyRend; 
	public float speed; 
	bool isCanonLooking = false; 

	public float fadeSpeed;    // How fast alpha value decreases.
	public Color fadeColor = new Color (0, 0, 0, 0);

	private Material myMaterial;    // Used to store material reference.
	private Color myColor;            // Used to store color reference.



	// Use this for initialization

	
	// Update is called once per frame
	void Start () {
		
		enemyRend = GetComponent<Renderer> ();
		Blink ();  
	}

	void Update (){
		//If the Canon is not looking at the object, then set the color of the ennemy to grey.
		if (!isCanonLooking) {
			enemyRend.material.SetColor ("_Color", Color.grey);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		goToPlayer(); //call function 
	}

	void goToPlayer() { //makes enemies move down at the speed variable specified 
		transform.position += -Vector3.forward *speed* Time.deltaTime;
	}

	void OnTriggerEnter( Collider canon){
		isCanonLooking = true;
		getColor ();
	}
	void OnTriggerStay( Collider canon){
		isCanonLooking = true;
		getColor ();
	}
	void OnTriggerExit( Collider canon){
		isCanonLooking = false;
	}
	void getColor(){
		if (enemyIdentity == "Red") {
			enemyRend.material.SetColor ("_Color", Color.red);
		} else if (enemyIdentity == "Blue") {
			enemyRend.material.SetColor ("_Color", Color.blue);
		} else {
			enemyRend.material.SetColor ("_Color", Color.green);
		}
	}

	void Blink () {

		for (int x = 0; x < 5; x++) {

//			yield return new WaitForSeconds (1); 
//
//			this.gameObject.GetComponent<Renderer>().enabled = false;
//
//			yield return new WaitForSeconds (1); 
//
//			this.gameObject.GetComponent<Renderer>().enabled = true;

			StartCoroutine (AlphaFade ()); 
			StartCoroutine (ColorFade ()); 

		}
	}

		IEnumerator AlphaFade () {
			// Alpha start value.
			float alpha = 1.0f;

			// Loop until aplha is below zero (completely invisible)
			while (alpha > 0.0f)
			{
				// Reduce alpha by fadeSpeed amount.
				alpha -= fadeSpeed * Time.deltaTime;

				// Alters material color slowly, changing the alpha each time
				myMaterial.color = new Color (myColor.r, myColor.g, myColor.b, alpha);

				yield return null;
			}
		}


		// This method fades from original color to "fadeColor"
		IEnumerator ColorFade () {
			// Lerp start value.
			float change = 0.0f;

			// Loop until lerp value is 1 (fully changed)
			while (change < 1.0f)
			{
				// Reduce change value by fadeSpeed amount.
				change += fadeSpeed * Time.deltaTime;

				myMaterial.color = Color.Lerp (myColor, fadeColor, change);

				yield return null;
			}
		} //end of colorfade


	}

