using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public static bool isDead = false;
	public GameObject lblGameOver;
	public static int playerScore = 0;
	public Text lblScore;
	// Use this for initialization
	void Start () {
		lblGameOver.SetActive( false);
		lblScore.text = playerScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			Time.timeScale = 0;
			lblGameOver.SetActive(true);
		}		
		if (Input.GetKeyDown (KeyCode.R)) {
			if (isDead == false) {
				Time.timeScale = 1;
				SceneManager.LoadScene ("Main");
			}
		}
	}
}
