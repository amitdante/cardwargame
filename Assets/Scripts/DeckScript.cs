using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckScript : MonoBehaviour
{
	public int player;
	public GameObject yourCard;
	public GameObject opponentCard;
	public Transform moveTarget1;
	public Transform moveTarget2;

	GameManager gm;
	// Use this for initialization
	void Start ()
	{
		gm = FindObjectOfType<GameManager> ();
		if (player == 1)
			this.GetComponent<Button> ().onClick.AddListener (ClickHandler);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void ClickHandler ()
	{
		GetComponent<Button> ().interactable = false;
		Debug.Log (gameObject.name + " Was Clicked");
		if (player == 1) {
			GameObject card = Instantiate (yourCard, this.transform);
			card.GetComponent <MovementHandler> ().target = moveTarget1;
			if (gm.yourCardsLeft > 0) {
				gm.yourCardsLeft--;
			} else {
				gm.looseScreen.SetActive (true);
				gm.canPlay = false;
			}

			gm.yourCards.Add (card);
			gm.DrawCard ();
		}
	}

	void OpponentClickHandler ()
	{
		GameObject card = Instantiate (opponentCard, this.transform);
		card.GetComponent <MovementHandler> ().target = moveTarget2;
		if (gm.opponentCardsLeft > 0) {
			gm.opponentCardsLeft--;
		} else {
			gm.winScreen.SetActive (true);
			gm.canPlay = false;
		}
	
		gm.opponentCards.Add (card);
	}

	public void ClickSimulator ()
	{
		OpponentClickHandler ();
	}

	public void SimulateAll ()
	{
		ClickHandler ();

	}
}
