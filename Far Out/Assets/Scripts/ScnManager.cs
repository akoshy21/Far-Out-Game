using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScnManager : MonoBehaviour {

	// variables for bars
	public Image crewBar;
	public Image suppliesBar;
	public Image fuelBar;
	public Image creditsBar;
	public Image progressBar;

	// variables for the bar fills
	Image crewBarFill;
	Image suppliesBarFill;
	Image creditsBarFill;
	Image fuelBarFill;
	Image progressBarFill;

	// variables for the floats
	private float crew;
	private float supplies;
	private float credits;
	private float fuel;
	private float progress;

	// text box where the player name needs to go
	public Text playerName;

	// Use this for initialization
	void Start () {

		// import the resource bar images
		crewBarFill = crewBar.GetComponent<Image> ();
		suppliesBarFill = suppliesBar.GetComponent<Image> ();
		fuelBarFill = fuelBar.GetComponent<Image> ();
		creditsBarFill = creditsBar.GetComponent<Image> ();
		progressBarFill = progressBar.GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {

		// make sure this is equivalent to the current value of the resources
		crew = GameManager.manager.crew;
		supplies = GameManager.manager.supplies;
		fuel = GameManager.manager.fuel;
		credits = GameManager.manager.credits;
		progress = GameManager.manager.distance;

		// make sure the bars are the right proportion of the fill bar
		crewBarFill.fillAmount = crew / 100;
		suppliesBarFill.fillAmount = supplies / 100;
		creditsBarFill.fillAmount = credits / 100;
		fuelBarFill.fillAmount = fuel / 100;
		progressBarFill.fillAmount = progress / 100;

		// set player name text to the player name
		playerName.text = GameManager.manager.playerName;
	}
}
