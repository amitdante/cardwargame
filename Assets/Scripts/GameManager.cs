using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
	[HideInInspector]
	public List<GameObject> yourCards;
	[HideInInspector]
	public List<GameObject> opponentCards;
	public GameObject yourDeck;
	public GameObject opponentDeck;
	public GameObject nextTurn;
	public GameObject war;
	public GameObject winScreen;
	public GameObject looseScreen;
	public Text cardsAtStake;
	public Text textYourCardsLeft;
	public Text textOpponentCardsLeft;
	public Text result;
	public bool warTime = false;
	public bool canPlay = true;
	public int yourCardsLeft = 23;
	public int opponentCardsLeft = 23;


	//public GameObject yourCard;
	//public GameObject opponentCard;
	bool winner;
	AIScript ai;


	void Start ()
	{
		yourCards = new List<GameObject> ();
		opponentCards = new List<GameObject> ();
		ai = opponentDeck.GetComponent <AIScript> ();
		nextTurn.GetComponent <Button> ().onClick.AddListener (NextTurn);

	}


	void Update ()
	{
		cardsAtStake.text = "Cards At Stake :" + (yourCards.Count + opponentCards.Count).ToString ();
		textYourCardsLeft.text = "Cards Left : \n" + yourCardsLeft.ToString ();
		textOpponentCardsLeft.text = "Cards Left : \n" + opponentCardsLeft.ToString ();
	
	}

	public void NextTurn ()
	{
		if (winner) {
			yourCardsLeft = yourCards.Count + opponentCards.Count + yourCardsLeft;
			foreach (GameObject card in yourCards) {
				card.GetComponent <MovementHandler> ().MoveBack (1);
			}
			foreach (GameObject card in opponentCards) {
				card.GetComponent <MovementHandler> ().MoveBack (1);
			}
		} else {
			opponentCardsLeft = yourCards.Count + opponentCards.Count + opponentCardsLeft;
			foreach (GameObject card in yourCards) {
				card.GetComponent <MovementHandler> ().MoveBack (2);
			}
			foreach (GameObject card in opponentCards) {
				card.GetComponent <MovementHandler> ().MoveBack (2);
			}
		}
		result.text = "";
		yourCards.Clear ();
		opponentCards.Clear ();
		nextTurn.SetActive (false);
		if (yourCardsLeft <= 0) {
			looseScreen.SetActive (true);
		} else if (opponentCardsLeft <= 0) {
			winScreen.SetActive (true);
		}
		yourDeck.GetComponent<Button> ().interactable = true;
	}

	public void DrawCard ()
	{
		ai.SimulateTouch ();
	}

	void DrawCardAll ()
	{
		if (canPlay) {
			yourDeck.GetComponent <DeckScript> ().SimulateAll ();
			opponentDeck.GetComponent <DeckScript> ().SimulateAll ();
		}
	}

	public void Battle ()
	{
		
		if (yourCards [yourCards.Count - 1].GetComponent <SetData> ().power > opponentCards [opponentCards.Count - 1].GetComponent <SetData> ().power) {
			YouWinBattle ();
		} else if (yourCards [yourCards.Count - 1].GetComponent <SetData> ().power < opponentCards [opponentCards.Count - 1].GetComponent <SetData> ().power) {
			YouLoseBattle ();
		} else if (yourCards [yourCards.Count - 1].GetComponent <SetData> ().power == opponentCards [opponentCards.Count - 1].GetComponent <SetData> ().power) {
			war.SetActive (true);
			warTime = true;
			Invoke ("DisableWar", 1.5f);
		}
	}

	public void YouWinBattle ()
	{
		//Debug.Log ("You win the battle");
		if (yourCards.Count > 1) {
			result.text = "YOU WIN THE WAR !";
		} else {
			result.text = "YOU WIN THE BATTLE !";
		}

		result.color = Color.green;
		winner = true;
		nextTurn.SetActive (true);
	}

	public void YouLoseBattle ()
	{
		//Debug.Log ("You Lose the battle");
		if (yourCards.Count > 1) {
			result.text = "YOU LOSE THE WAR !";
		} else {
			result.text = "YOU LOSE THE BATTLE !";
		}

		result.color = Color.red;
		winner = false;
		nextTurn.SetActive (true);

	}

	void DisableWar ()
	{
		war.SetActive (false);
		DrawManyCards (yourCards [yourCards.Count - 1].GetComponent <SetData> ().power);

	}

	void DrawManyCards (int i)
	{
		
		int cardsDrawn = 0;
		while (cardsDrawn != i - 1) {
			Invoke ("DrawCardAll", cardsDrawn == 0 ? 1 : (cardsDrawn + 1));
			cardsDrawn++;
		}
		Invoke ("DisableWarTime", cardsDrawn + 1.9f);
		Invoke ("DrawCardAll", cardsDrawn + 1);
	}

	void DisableWarTime ()
	{
		warTime = false;
	}

	public void MainMenuButton ()
	{
		SceneManager.LoadScene ("Menu");
	}
}
