﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Text scoreText;
	public Button[] buttons;
	public Button pauseButton;
	public AudioManager am;

	public bool gameOver;
	int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	void scoreUpdate() {
		if (!gameOver) {
			score += 1;
		}
	}

	public void gameOverActivated() {
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
	}

	public void play() {
		Application.LoadLevel ("Level1");
	}

	public void Pause() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			am.carSound.Stop ();
			pauseButton.GetComponentInChildren<Text>().text = ">";
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			if (!gameOver) {
				am.carSound.Play ();
			}
			pauseButton.GetComponentInChildren<Text>().text = "| |";
		}
	}

	/** public void Replay() {
		Application.LoadLevel (Application.loadedLevel);
	} */

	public void Menu() {
		Application.LoadLevel ("Menu");
	}

	public void Exit() {
		Application.Quit ();
	}
}
