﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameTimer : MonoBehaviour {

	public float myTimer = 45;
	public Text timer;
	private bool timerIsRunning = true;
	public GameObject timesUp;
	public GameObject playAgain;
	public GameObject Quit;
	public GameObject youWin; 



	void Start () {
		timer = GetComponent<Text> ();
	}

	//void CheckTimesUp(){
	//    if (myTimer <= 0) {
	//        timesUp.SetActive (true);
	//    }
	//}



	void Update () {
		if (timerIsRunning) {
			myTimer -= Time.deltaTime;
			timer.text = myTimer.ToString ("0");
			//print (myTimer);
			if (youWin.activeSelf == true) {
				timerIsRunning = false;
			}
			if (myTimer <= 0) {
				myTimer = 0;
				timerIsRunning = false;
				timesUp.SetActive (true);
				playAgain.SetActive (true);
				Quit.SetActive (true);
				//timer.text = "Game Over";
			}

//			if(youWin.activeSelf == true){
//				timerIsRunning = false;
//			}
			}
		}
			

		
}