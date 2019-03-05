using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour {

	public Text descriptionText;  // define variable for the description text
	public Image crewmanPortrait;  // define variable for the crew picture
	public Image change;
	public Text buttonOneText;  // define variable for button one text
	public Text buttonTwoText;  // define variable for the button two text

	// define variables to import buttons
	public Button buttonOne;
	public Button buttonTwo;

	// define variables to import crew images
	public Sprite pilotImage;
	public Sprite huskImage;
	public Sprite psionImage;
	public Sprite scienceImage;
	public Sprite commanderImage;
	public Sprite securityImage;

	// define variables for increase / decrease
	public Sprite Increase;
	public Sprite Decrease;
	public Sprite noChange;

	// import the audio for the event change
	public AudioClip changeEvent;

	// create an array of event objects
	public Event[] events;

	// set up randomization variable
	int eventNum;
	System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {

		// fill the array with events
		events = new Event[13];
		// construct the events
		for (int i = 0; i < events.Length; i++) {
			events[i] = new Event(pilotImage, "x", "x", "x", "x", 0, 0, "x", "x", "x", 0, 0);
		}

		// set up event 0 - inhabited planet
		events [0].crewman = pilotImage;
		events [0].eventText = "WE'RE NEARING AN INHABITED PLANET. WHAT SHOULD WE DO?";
		events [0].optionOne = "LAND AND MAKE CONTACT";
		events [0].optionOneVariableA = "supplies";
		events [0].optionOneChangeA = 1;
		events [0].optionOneVariableB = "distance";
		events [0].optionOneChangeB = 0.5f;
		events [0].optionTwo = "KEEP FLYING";
		events [0].optionTwoVariableA = "supplies";
		events [0].optionTwoChangeA = 0;
		events [0].optionTwoVariableB = "null";
		events [0].optionTwoChangeB = 0;

		// set up event 1 - virus
		events [1].crewman = scienceImage;
		events [1].eventText = "AN UNKNOWN VIRUS HAS BEEN LOOSED ON THE SHIP. WHAT SHOULD WE DO?";
		events [1].optionOne = "QUARANTINE IT";
		events [1].optionOneVariableA = "crew";
		events [1].optionOneChangeA = -1;
		events [1].optionOneVariableB = "null";
		events [1].optionOneChangeB = -1;
		events [1].optionTwo = "LAND ON A NEARBY PLANET AND FIND A CURE";
		events [1].optionTwoVariableA = "credits";
		events [1].optionTwoChangeA = -1;
		events [1].optionTwoVariableB = "supplies";
		events [1].optionTwoChangeB = 1;

		// set up event 2 - boarding
		events [2].crewman = securityImage;
		events [2].eventText = "WE HAVE HOSTILE ALIENS ONBOARD. WHAT SHOULD WE DO?";
		events [2].optionOne = "KEEP THE CREW SAFE";
		events [2].optionOneVariableA = "supplies";
		events [2].optionOneChangeA = -1;
		events [2].optionOneVariableB = "credits";
		events [2].optionOneChangeB = -2;
		events [2].optionTwo = "PROTECT OUR CARGO";
		events [2].optionTwoVariableA = "crew";
		events [2].optionTwoChangeA = -1;
		events [2].optionTwoVariableB = "credits";
		events [2].optionTwoChangeB = -1;

		// set up event 3 - supernova
		events [3].crewman = psionImage;
		events [3].eventText = "WE'RE ABOUT TO PASS A SUPER NOVA. WHAT SHOULD WE DO?";
		events [3].optionOne = "DOUBLE SPEED THROUGH THE SYSTEM";
		events [3].optionOneVariableA = "fuel";
		events [3].optionOneChangeA = -2;
		events [3].optionOneVariableB = "distance";
		events [3].optionOneChangeB = 2;
		events [3].optionTwo = "ADJUST TRAJECTORY";
		events [3].optionTwoVariableA = "distance";
		events [3].optionTwoChangeA = -0.5f;
		events [3].optionTwoVariableB = "null";
		events [3].optionTwoChangeB = 0;

		// set up event 4 - drive core
		events [4].crewman = pilotImage;
		events [4].eventText = "THE DRIVE CORE IS MALFUNCTIONING. WHAT DO WE DO?";
		events [4].optionOne = "LAND AND REPAIR IT";
		events [4].optionOneVariableA = "distance";
		events [4].optionOneChangeA = -1;
		events [4].optionOneVariableB = "supplies";
		events [4].optionOneChangeB = -1;
		events [4].optionTwo = "KEEP FLYING AND REPAIR IT";
		events [4].optionTwoVariableA = "fuel";
		events [4].optionTwoChangeA = -3;
		events [4].optionTwoVariableB = "supplies";
		events [4].optionTwoChangeB = -1;

		// set up event 5 - oxygen
		events [5].crewman = huskImage;
		events [5].eventText = "WE'RE RUNNING LOW ON OXYGEN. WHAT SHOULD WE DO?";
		events [5].optionOne = "RESTRICT USE TO ESSENTIAL PERSONNEL ONLY";
		events [5].optionOneVariableA = "crew";
		events [5].optionOneChangeA = -2;
		events [5].optionOneVariableB = "null";
		events [5].optionOneChangeB = 0;
		events [5].optionTwo = "LOOK FOR A SUITABLE PLANET TO RESUPPLY";
		events [5].optionTwoVariableA = "distance";
		events [5].optionTwoChangeA = -2;
		events [5].optionTwoVariableB = "supplies";
		events [5].optionTwoChangeB = 2;

		// set up event 6 - robbed
		events [6].crewman = psionImage;
		events [6].eventText = "DID YOU NOTICE ONE OF THE VISITING CREWS TAKING SOMETHING?";
		events [6].optionOne = "THEY STOLE FUEL";
		events [6].optionOneVariableA = "fuel";
		events [6].optionOneChangeA = -2;
		events [6].optionOneVariableB = "null";
		events [6].optionTwo = "THEY STOLE FOOD";
		events [6].optionTwoVariableA = "supplies";
		events [6].optionTwoChangeA = -2;
		events [6].optionTwoVariableB = "null";

		// set up event 7 - pirates
		events [7].crewman = commanderImage;
		events [7].eventText = "PIRATES HAVE BOARDED. WHAT SHOULD WE DO?";
		events [7].optionOne = "FIGHT THEM OFF";
		events [7].optionOneVariableA = "crew";
		events [7].optionOneChangeA = -1;
		events [7].optionOneVariableB = "null";
		events [7].optionOneChangeB = 0;
		events [7].optionTwo = "HIDE";
		events [7].optionTwoVariableA = "supplies";
		events [7].optionTwoChangeA = -2;
		events [7].optionTwoVariableB = "credits";
		events [7].optionTwoChangeB = -1;

		// set up event 8 - fuel
		events [8].crewman = pilotImage;
		events [8].eventText = "WE'RE SUFFERING A FUEL LEAK. WHAT SHOULD WE DO?";
		events [8].optionOne = "FIX IT";
		events [8].optionOneVariableA = "supplies";
		events [8].optionOneChangeA = -1;
		events [8].optionOneVariableA = "null";
		events [8].optionTwo = "KEEP GOING";
		events [8].optionTwoVariableA = "fuel";
		events [8].optionTwoChangeA = -3;
		events [8].optionTwoVariableA = "null";

		// set up event 9 - INFESTATION
		events [9].crewman = scienceImage;
		events [9].eventText = "AN ALIEN SPECIES OF FLUFFBALLS HAS INFESTED THE SHIP";
		events [9].optionOne = "KILL THEM";
		events [9].optionOneVariableA = "crew";
		events [9].optionOneChangeA = -1;
		events [9].optionOneVariableB = "null";
		events [9].optionTwo = "PAY FOR THEIR REMOVAL";
		events [9].optionTwoVariableA = "credits";
		events [9].optionTwoChangeA = -2;
		events [9].optionTwoVariableB = "null";

		// set up event 10 - away mission
		events [10].crewman = securityImage;
		events [10].eventText = "THE AWAY TEAM WAS CAPTURED. THEY'RE BEING RANSOMED BACK.";
		events [10].optionOne = "PAY";
		events [10].optionOneVariableA = "credits";
		events [10].optionOneChangeA = -2;
		events [10].optionOneVariableB = "crew";
		events [10].optionOneChangeB = 1;
		events [10].optionTwo = "DON'T PAY";
		events [10].optionTwoVariableA = "crew";
		events [10].optionTwoChangeA = -2;
		events [10].optionTwoVariableB = "null";

		// set up event 11 - Moral Issue
		events [11].crewman = commanderImage;
		events [11].eventText = "THERE'S BEEN TALK OF A MUTINY";
		events [11].optionOne = "MAKE A DEAL WITH THE UNHAPPY CREW";
		events [11].optionOneVariableA = "supplies";
		events [11].optionOneChangeA = -1;
		events [11].optionOneVariableB = "credits";
		events [11].optionOneChangeB = -1;
		events [11].optionTwo = "ARREST THEM";
		events [11].optionTwoVariableA = "crew";
		events [11].optionTwoChangeA = -2;
		events [11].optionTwoVariableB = "null";
		events [11].optionTwoChangeB = 0;

		// set up event 12 - Fuel Station
		events [12].crewman = huskImage;
		events [12].eventText = "THERE'S A FUELING STATION NEARBY. SHOULD WE STOP?";
		events [12].optionOne = "KEEP FLYING";
		events [12].optionOneVariableA = "supplies";
		events [12].optionOneChangeA = 0;
		events [12].optionOneVariableB = "null";
		events [12].optionOneChangeB = 0;
		events [12].optionTwo = "REFUEL";
		events [12].optionTwoVariableA = "fuel";
		events [12].optionTwoChangeA = 1;
		events [12].optionTwoVariableB = "credits";
		events [12].optionTwoChangeB = -1;

		// set up btn variables
		Button btnOne = buttonOne.GetComponent<Button>();
		btnOne.onClick.AddListener (TaskOnClickOne);
		Button btnTwo = buttonTwo.GetComponent<Button>();
		btnTwo.onClick.AddListener (TaskOnClickTwo);


		// randomize a number from 1 to 11 for the first event.
		eventNum = rnd.Next(0, 12);
	}

	void Update() {

		// update the description, portrait, & buttons in the event box
		descriptionText.text = events [eventNum].eventText;
		crewmanPortrait.sprite = events [eventNum].crewman;
		buttonOneText.text = events [eventNum].optionOne;
		buttonTwoText.text = events [eventNum].optionTwo;

		Debug.Log (eventNum);
	}

	void TaskOnClickOne()
	{
		// define a variable for the change
		float changeA, changeB;
		changeA = events[eventNum].optionOneChangeA * 10;
		changeB = events [eventNum].optionOneChangeB * 10;

		// check which variable is being modified, and adjust it.
		if(!events[eventNum].optionOneVariableA.Equals("null"))
		{
			if (events[eventNum].optionOneVariableA.Equals("crew"))
				{
					GameManager.manager.crew += changeA;
				}
			else if (events[eventNum].optionOneVariableA.Equals("supplies"))
				{
					GameManager.manager.supplies += changeA;
				}
			else if (events[eventNum].optionOneVariableA.Equals("credits"))
				{
					GameManager.manager.credits += changeA;
				}
			else if (events[eventNum].optionOneVariableA.Equals("fuel"))
				{
					GameManager.manager.fuel += changeA;
				}
			else if (events[eventNum].optionOneVariableA.Equals("distance"))
			{
				GameManager.manager.distance += changeA;
			}
		}


		// check second set of variables
		if(!events[eventNum].optionOneVariableB.Equals("null"))
		{
			if (events[eventNum].optionOneVariableB.Equals("crew"))
			{
				GameManager.manager.crew += changeB;
			}
			else if (events[eventNum].optionOneVariableB.Equals("supplies"))
			{
				GameManager.manager.supplies += changeB;
			}
			else if (events[eventNum].optionOneVariableB.Equals("credits"))
			{
				GameManager.manager.credits += changeB;
			}
			else if (events[eventNum].optionOneVariableB.Equals("fuel"))
			{
				GameManager.manager.fuel += changeB;
			}
			else if (events[eventNum].optionOneVariableB.Equals("distance"))
			{
				GameManager.manager.distance += changeB;
			}
		}

		// deselect the button
		EventSystem.current.SetSelectedGameObject (null);
		// add to distance
		GameManager.manager.distance += 5;

		// move to next situation
		NextSituation ();
	}

	void TaskOnClickTwo()
	{
		// define a variable for the change
		float changeA, changeB;
		changeA = events[eventNum].optionTwoChangeA * 10;
		changeB = events [eventNum].optionTwoChangeB * 10;

		// check which variable is being modified, and adjust it.
		if(!events[eventNum].optionTwoVariableA.Equals("null"))
		{
			if (events[eventNum].optionTwoVariableA.Equals("crew"))
			{
				GameManager.manager.crew += changeA;
			}
			else if (events[eventNum].optionTwoVariableA.Equals("supplies"))
			{
				GameManager.manager.supplies += changeA;
			}
			else if (events[eventNum].optionTwoVariableA.Equals("credits"))
			{
				GameManager.manager.credits += changeA;
			}
			else if (events[eventNum].optionTwoVariableA.Equals("fuel"))
			{
				GameManager.manager.fuel += changeA;
			}
			else if (events[eventNum].optionTwoVariableA.Equals("distance"))
			{
				GameManager.manager.distance += changeA;
			}
		}

		// check second set of variables
		if(!events[eventNum].optionTwoVariableB.Equals("null"))
		{
			if (events[eventNum].optionTwoVariableB.Equals("crew"))
			{
				GameManager.manager.crew += changeB;
			}
			else if (events[eventNum].optionTwoVariableB.Equals("supplies"))
			{
				GameManager.manager.supplies += changeB;
			}
			else if (events[eventNum].optionTwoVariableB.Equals("credits"))
			{
				GameManager.manager.credits += changeB;
			}
			else if (events[eventNum].optionTwoVariableB.Equals("fuel"))
			{
				GameManager.manager.fuel += changeB;
			}
			else if (events[eventNum].optionTwoVariableB.Equals("distance"))
			{
				GameManager.manager.distance += changeB;
			}
		}

		// deselect button
		EventSystem.current.SetSelectedGameObject (null);
		// add to distance
		GameManager.manager.distance += 5;
		
		// move to next situation
		NextSituation ();
	}

	void NextSituation()
	{
		// create variables to store the new event number and the previous event number
		int newNum;
		int previousEvent = eventNum;

		// randomize a new number
		newNum = rnd.Next (0, 12);

		// check if the new event # is equal to the old one, and if so, add one, unless the newNumber is equal to 10, in which case randomize between 1 and 3
		if (newNum == previousEvent) {
			newNum++;
			if (newNum == 12) {
				newNum = rnd.Next (1, 5);
			}
		}

		// import sound and play sound
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();

		// set eventNum equal to newNum, in order to update the screen.
		eventNum = newNum;
	}
}
