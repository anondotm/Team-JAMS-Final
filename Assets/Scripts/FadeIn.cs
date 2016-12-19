using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour 
{
	public float fadeSpeed;    // How fast alpha value decreases.
	public Color fadeColor = new Color (0, 0, 0, 0);

	private Material myMaterial;    // Used to store material reference.
	private Color myColor;            // Used to store color reference.


	void Start ()
	{
		// Get reference to object's material.
		myMaterial = GetComponent <Renderer> ().material;

		// Get material's starting color value.
		myColor = myMaterial.color;

		// Must use "StartCoroutine()" to execute 
		// methods with return type of "IEnumerator".
		StartCoroutine (ColorFade ());
	}

	// This method fades only the alpha.
	IEnumerator AlphaFade ()
	{
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
	IEnumerator ColorFade ()
	{
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
	}
}

