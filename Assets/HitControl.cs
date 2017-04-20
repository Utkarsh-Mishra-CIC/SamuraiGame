using UnityEngine;
using System.Collections;

public class HitControl : MonoBehaviour {
    GameObject Player;
	//public float turning;
	public GameObject[] UIExtraLives;
	private static double EnemyHealth;
	public GameObject UIGameEnd;
	// Use this for initialization
	void Start () {
		EnemyHealth = 4;
		GameObject thePlayer = GameObject.Find("Player");
//		Script playerScript = thePlayer.GetComponent<PlayerScript>();
//		playerScript.Health -= 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth == 0) {
			if (Time.timeScale > 0f) {
				UIGameEnd.SetActive(true); // this brings up the pause UI
				Time.timeScale = 0f; // this pauses the game action
				PlayerControl.enableinput = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			EnemyHealth = EnemyHealth - 1;
			//if (this.transform.paren)
			for (int i = 0; i < UIExtraLives.Length; i++) {
				if (i < (EnemyHealth)) { // show one less than the number of lives since you only typically show lifes after the current life in UI
					UIExtraLives [i].SetActive (true);
				} else {
					UIExtraLives [i].SetActive (false);
				}
			}
		}
		print("Touched!");
	}
}
