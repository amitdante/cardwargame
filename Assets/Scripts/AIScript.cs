using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

	DeckScript deck;

	void Start ()
	{
		deck = GetComponent <DeckScript> ();
	}

	public void SimulateTouch ()
	{
		deck.ClickSimulator ();
	}
}
