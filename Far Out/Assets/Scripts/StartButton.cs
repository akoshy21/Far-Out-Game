using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	// button variable to utilize the button.
	Button startButton;

	// Use this for initialization
	void Awake () {
		// import button
		startButton = GetComponent<Button> ();
		// add listener to see if button is clicked
		startButton.onClick.AddListener (TaskOnClick);	
	}
	void TaskOnClick(){
		// reset resources
		GameManager.manager.crew = 100;
		GameManager.manager.credits = 100;
		GameManager.manager.supplies = 100;
		GameManager.manager.fuel = 100;
		GameManager.manager.distance = 0;
	
		// reset ending and bools for ending
		GameManager.manager.ending = 0;
		GameManager.manager.gameOver = false;
		GameManager.manager.firstRun = true;

		// load main game
		SceneManager.LoadScene ("maingame", LoadSceneMode.Single);
	}
}
