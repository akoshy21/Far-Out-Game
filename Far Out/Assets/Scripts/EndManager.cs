using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

	// int to import end #
	private int end;

	// import crew images
	public Image pilot;
	public Image commander;
	public Image husk;
	public Image psion;
	public Image science;
	public Image security;

	// import description
	public Text description;

	// Use this for initialization
	void Start () {
		// import end #
		end = GameManager.manager.ending;
	}

	// Update is called once per frame
	void Update () {
		if (end != 5) {
			// set crew images to fade to a gray tone
			pilot.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
			commander.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
			husk.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
			psion.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
			security.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
			science.GetComponent<Image> ().CrossFadeAlpha (0.3f, 2f, false);
		}

		// run the different endings
		if (end == 1) {
			EndCrew ();
		}
		else if (end == 2) {
			EndSupplies ();
		}
		else if (end == 3) {
			EndCredits ();
		}
		else if (end == 4) {
			EndFuel ();
		}
		else if (end == 5) {
			EndDistance ();
		}

		// go to credit scene
		if (Input.anyKey) {
			SceneManager.LoadScene ("creditscene", LoadSceneMode.Single);
		}
	}

	// function to fill text with crew ending information
	void EndCrew(){
		description.text = "CAPTAIN " + GameManager.manager.playerName + 
			". YOUR CREW HAS PERISHED. THEY PUT THEIR FAITH IN YOU, BUT DUE TO YOUR LEADERSHIP, THEY DIED." +
			"\n YOU ARE LEFT STRANDED; FAR FROM HOME. ALONE.";
	}
	// function to fill text with supply ending information
	void EndSupplies(){
		description.text = "CAPTAIN " + GameManager.manager.playerName + 
			". YOU HAVE RUN OUT OF SUPPLIES. WITH NO FOOD OR WATER, YOU AND YOUR CREW HAVE LITTLE HOPE FOR SURVIVAL." +
			"THERE IS NOT MUCH YOU CAN DO NOW BUT WAIT FOR THE INEVITABLE PULL OF THE DARKNESS.";
	}
	// function to fill text with credits ending information
	void EndCredits(){
		description.text = "CAPTAIN " + GameManager.manager.playerName + 
			". WITHOUT MONEY, ONE CANNOT DO MUCH IN THIS WORLD IT SEEMS. YOUR LACK, THEREFORE, HAS LEFT YOU WEAKENED." +
			"FEW WISH TO WORK WITH YOU, AND YOU CAN NO LONGER OBTAIN WHAT YOU NEED. YOU ARE STUCK, QUITE POSSIBLY FOR FOREVER.";
	}
	// function to fill text with fuel ending information
	void EndFuel(){
		description.text = "CAPTAIN " + GameManager.manager.playerName + 
			". FUEL IS THE DRIVING FORCE BEHIND YOUR SHIP. IT POWERS IT FORWARD, SENDING YOU CLOSER TO YOUR DESTINATION." +
			"YET YOU HAVE WASTED YOUR RESOURCE AND ALL THAT IS LEFT ARE REMNANTS OF YOUR SHIP; A HUNK OF METAL, FLOATING THROUGH SPACE.";
	}
	// function to fill text with distance ending information
	void EndDistance(){
		description.text = "CAPTAIN " + GameManager.manager.playerName + 
			". YOUR CREW WAS RIGHT TO LEAN ON YOU FOR SUPPORT. YOU LED THEM THROUGH THE CHAOS AND TERROR OF SPACE AND" +
			" BROUGHT THEM HOME. THANKS TO YOU, YOUR CREW WILL SLEEP SAFELY IN THEIR BEDS TONIGHT AND YOU....\n" +
			"YOU ARE A HERO.";
	}}
