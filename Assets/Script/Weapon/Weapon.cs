using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

	public const int MAX_SPAWN_POINTS = 13;
	public int streak;
	public float timeLeft;

	// UI texts
	public Text killCountText;
	public Text timerCountText;
	public Text gameOverText;
	public Text yourScoreText;

	public float seconds,minutes;

	GameObject[] spawnPoints = new GameObject[MAX_SPAWN_POINTS];
	GameObject enemy, targetCube;
	public AudioClip weaponFire;
	public AudioSource audioS;
	public AudioClip bellRing;
	public AudioSource enemyHeadSource;

	private Animator anim;

	int [] flag = new int[MAX_SPAWN_POINTS];
	private int counter = 0;

	public int bulletsPerMag = 30;
	public int bulletsLeft = 120;
	public int currentBullets;
	public float range = 100f;

	public Transform shootPoint;

	public float fireRate = .5f;
	public float fireTimer;

	private bool gameEnd;


	// Use this for initialization
	void Start () {
		gameEnd = false;
		currentBullets = bulletsPerMag;
		gameOverText.text = "";
		yourScoreText.text = "";
		streak = 0;
		timeLeft = 60.0f;
		setFlagValue(flag, 0);
		GetSpawnPoints();
		GetEnemy();
		GetEnemyHitBox();
		setKillCountText();
		anim = GetComponent<Animator>();

	}

	void FixedUpdate(){
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
		if(info.IsName("Fire")) anim.SetBool("Fire", false);
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		setTimerCountText ();
		if(Input.GetButton("Fire1")){
			Fire();
		}

		if(fireTimer < fireRate){
			fireTimer += Time.deltaTime;
		}

		if (timeLeft <= 0.0) {
			gameOver ();
		}



	}

	private void Fire(){
		if(fireTimer <  fireRate) return;

		audioS.PlayOneShot(weaponFire);
		RaycastHit hit;

		if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)){

			//If player hits enemy head
			if(hit.transform.name == targetCube.transform.name){
				Debug.Log(hit.transform.name + " is hit!");
				enemyHeadSource.PlayOneShot(bellRing);
				SetEnemyPosition(enemy, spawnPoints[GetRandomNumber()]);
				streak++;
				setKillCountText();
				Debug.Log("Your Streak: " +streak);
			}else{
				Debug.Log(hit.transform.name + "is hit instead!");
				gameOver ();
				streak = 0;
			}
			
		}else{
			Debug.Log("Score is: " +streak);
			gameOver ();
			streak = 0;
		}

		anim.SetBool("Fire", true);
		currentBullets--;

		fireTimer = 0.0f;
	}

	private void GetSpawnPoints(){
		spawnPoints[0] = GameObject.Find("spawnPoint1");
		spawnPoints[1] = GameObject.Find("spawnPoint2");
		spawnPoints[2] = GameObject.Find("spawnPoint3");
		spawnPoints[3] = GameObject.Find("spawnPoint4");
		spawnPoints[4] = GameObject.Find("spawnPoint5");
		spawnPoints[5] = GameObject.Find("spawnPoint6");
		spawnPoints[6] = GameObject.Find("spawnPoint7");
		spawnPoints[7] = GameObject.Find("spawnPoint8");
		spawnPoints[8] = GameObject.Find("spawnPoint9");
		spawnPoints[9] = GameObject.Find("spawnPoint10");
		spawnPoints[10] = GameObject.Find("spawnPoint11");
		spawnPoints[11] = GameObject.Find("spawnPoint12");
		spawnPoints[12] = GameObject.Find("spawnPoint13");
	}

	private void setKillCountText(){
		killCountText.text = "Kill Count: " + streak.ToString (); 
	}

	private void setTimerCountText(){
		timerCountText.text = "Time : " + timeLeft.ToString ("00"); 
	}


	private void GetEnemy(){
		enemy = GameObject.Find("enemy");
	}

	//Respawns the enemy
	private void SetEnemyPosition(GameObject a, GameObject b){
		a.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, b.transform.position.z);
	}

	private int GetRandomNumber(){
		int randomNumber = Random.Range(0,MAX_SPAWN_POINTS);
		while(flag[randomNumber] != 1){
			randomNumber = Random.Range(0,MAX_SPAWN_POINTS);
			flag[randomNumber] = 1;
		}

		counter += 1;
		if(counter == MAX_SPAWN_POINTS){
			counter = 0;
			setFlagValue(flag, 0);
		}

		return randomNumber;
		
	}

	private void setFlagValue(int[] flag, int setValue){
		for(int i=0; i<MAX_SPAWN_POINTS; i++){
			flag[i] = setValue;
		}
	}

	private void GetEnemyHitBox(){
		targetCube = GameObject.Find("TargetCube");
	}

	private void gameOver () {
		gameOverText.text = "Game Over";
		yourScoreText.text = "Your Score: " + streak;
		timerCountText.text = "";
		gameEnd = true;
		Application.Quit();
	}

}
