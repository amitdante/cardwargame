using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateCards : MonoBehaviour
{
	public List<CardData> allCards;
	// Use this for initialization
	void Start ()
	{
		allCards = new List<CardData> ();
		for (int i = 1; i < 14; i++) {
			for (int k = 0; k < 4; k++) {
				CardData newCard = new CardData (i);
				allCards.Add (newCard);
				//Debug.Log (newCard.value);
			}

		}
		GetComponent <GameManager> ().allcardsData = allCards;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

public class CardData
{
	public int value;

	public CardData (int value)
	{
		this.value = value;
	}
}
