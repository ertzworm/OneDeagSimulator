using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int bulletsPerMag = 30;
	public int bulletsLeft = 120;
	public int currentBullets;
	public float range = 100f;


	public Transform shootPoint;

	public float fireRate = 0.05f;
	public float fireTimer;
	// Use this for initialization
	void Start () {
		currentBullets = bulletsPerMag;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			Fire();
		}

		if(fireTimer < fireRate){
			fireTimer += Time.deltaTime;
		}
	}

	private void Fire(){
		if(fireTimer <  fireRate) return;
		Debug.Log("Fired!");

		RaycastHit hit;

		if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name + " is hit!");
		}

		currentBullets--;

		fireTimer = 0.0f;
	}
}
