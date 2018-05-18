using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {

	public AudioClip weaponFire;
	public AudioSource audioS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WeanpoFire(){
		Debug.Log("Playing sound!");
		audioS.PlayOneShot(weaponFire);
	}
}
