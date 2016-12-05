using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPickupScript : MonoBehaviour {

	//object referencing cannon
	public GameObject cannonObject;

	//object referencing exclamation
	public GameObject promptObject;

	// records initial movement speed for character on start
	float initialMoveSpeed = 0;
	// gets and stores curren movespeed from "Movement" script so we can manipulate it based on ammoHeld
	public float currentMoveSpeed;

	//GameObject currently being "looked" at
	public GameObject currentHighlight;


	//list that stores player's "held" ammo
	public List<string> heldAmmo = new List<string>(); 
	//updates with size of heldAmmo list, used to limit amt. of ammo carried
	public int heldAmmoSize;
	//UI text element displaying ammo held
	public GameObject heldAmmoText;

	//Array with positions to instantiate "physical" ammo
	public GameObject physicalRed;
	public GameObject physicalGreen;
	public GameObject physicalBlue;
	public Transform[] heldAmmoPosition;
	public List<GameObject> physicalAmmoList = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
