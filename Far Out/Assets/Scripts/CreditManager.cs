using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if a key is pressed go back to the start.
		if (Input.anyKey) {
			SceneManager.LoadScene ("startscreen", LoadSceneMode.Single);
		}
	}
}
