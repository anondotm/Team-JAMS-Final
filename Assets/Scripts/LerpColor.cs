using UnityEngine;
using System.Collections;

public class LerpColor : MonoBehaviour {
	Renderer bulletRend;
	public Color lerpedColor = Color.white;
	public Color bulletColor = Color.black;
	void Start(){
		bulletRend = GetComponent<Renderer> ();
	}
	void Update() {
		lerpedColor = Color.Lerp(Color.black, bulletColor, Mathf.PingPong(Time.time, 1));
		bulletRend.material.SetColor ("_Color", lerpedColor);
	}
	public void LerpAmmoIndicatorColor(Color color, GameObject AmmoIndicator){
		bulletColor = color;
		bulletRend = AmmoIndicator.GetComponent<Renderer> ();
	}
}
