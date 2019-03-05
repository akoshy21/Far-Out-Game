using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	// set up variables for scroll speed and tile size
	public float scrollSpeed;
	public float tileSizeX;

	// create a vector for the start position
	private Vector3 startPosition;

	void Start ()
	{
		// store the start position in the vector
		startPosition = transform.position;
	}

	void Update ()
	{
		// create a new float that loops through the values between the time * scroll speeed and the tile size.
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);

		// shift the backgrounds position
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
