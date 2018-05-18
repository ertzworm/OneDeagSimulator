using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public bool isNight = false;


	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame(){
		Debug.Log("You have pressed this!");
		Application.Quit();
	}

	public void NightMode(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}
	
}
