using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create a public class called event for use
public class Event
{
	// set up the variables needed
	public Sprite crewman;
	public string eventText;
	public string optionOne;
	public string optionOneVariableA;
	public string optionOneVariableB;
	public float optionOneChangeA;
	public float optionOneChangeB;
	public string optionTwo;
	public string optionTwoVariableA;
	public string optionTwoVariableB;
	public float optionTwoChangeA;
	public float optionTwoChangeB;

	// create a constructor
	public Event(Sprite c, string e, string one, string oneVA, string oneVB, float oneCA, float oneCB, string two, string twoVA, string twoVB, float twoCA, float twoCB)
	{
		crewman = c;
		eventText = e;
		optionOne = one;
		optionOneVariableA = oneVA;
		optionOneChangeA = oneCA;
		optionOneVariableB = oneVB;
		optionOneChangeB = oneCB;
		optionTwo = two;
		optionTwoVariableA = twoVA;
		optionTwoChangeA = twoCA;
		optionTwoVariableB = twoVB;
		optionTwoChangeB = twoCB;
	}
}