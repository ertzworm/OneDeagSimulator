using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJS : MonoBehaviour {


	private GameObject laser;
	public bool isActive;
	// Use this for initialization
	void Start () {
		laser = GameObject.Find("laser");
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("f")){

			Debug.Log(isActive);
			if(isActive == false){
				
				laser.SetActive(true);
				isActive = true;
			}else{
				laser.SetActive(false);
				isActive = false;
			}
		}
	}
}
