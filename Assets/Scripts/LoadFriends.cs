﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadFriends : MonoBehaviour {
	public Button startButton;



	public void Start () {
		startButton = startButton.GetComponent<Button>();
	}

	public void StartLevel(){
		SceneManager.LoadScene("Friends_lvl");

	}
}