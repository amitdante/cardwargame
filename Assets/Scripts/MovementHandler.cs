using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
	[HideInInspector]
	public Transform target;
	public GameObject front;
	// Use this for initialization
	public bool fightable = true;
	GameManager gm;

	void Start ()
	{
		gm = FindObjectOfType<GameManager> ();
		StartFlipping ();
		MoveToCenter ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void MoveToCenter ()
	{
		iTween.MoveTo (this.gameObject, iTween.Hash ("position", target.position, "time", 1, "easetype", iTween.EaseType.linear));
		iTween.ScaleTo (this.gameObject, iTween.Hash ("scale", new Vector3 (0.8f, 0.8f, 1), "time", 1, "easetype", iTween.EaseType.linear, "oncomplete", "ReadyToBattle"));

	}

	public void StartFlipping ()
	{
		iTween.RotateTo (this.gameObject, iTween.Hash ("rotation", new Vector3 (0, 90, 0), "time", 0.5f, "easetype", iTween.EaseType.linear, "oncomplete", "SwitchAnimation"));

	}

	void SwitchAnimation ()
	{
		front.SetActive (true);
		iTween.RotateTo (this.gameObject, iTween.Hash ("rotation", new Vector3 (0, 180, 0), "time", 0.5f, "easetype", iTween.EaseType.linear));
	}

	void ReadyToBattle ()
	{
		if (fightable && this.transform.parent.gameObject.GetComponent <DeckScript> ().player == 1 && !gm.warTime) {
			gm.Battle ();
		}
	}

	public void MoveBack (int target)
	{
		if (target == 1) {
			iTween.MoveTo (this.gameObject, iTween.Hash ("position", gm.yourDeck.transform.position, "time", 1, "easetype", iTween.EaseType.linear));
			iTween.ScaleTo (this.gameObject, iTween.Hash ("scale", new Vector3 (0, 0, 0), "time", 1, "easetype", iTween.EaseType.linear, "oncomplete", "DestroySelf"));
		} else {
			iTween.MoveTo (this.gameObject, iTween.Hash ("position", gm.opponentDeck.transform.position, "time", 1, "easetype", iTween.EaseType.linear));
			iTween.ScaleTo (this.gameObject, iTween.Hash ("scale", new Vector3 (0, 0, 0), "time", 1, "easetype", iTween.EaseType.linear, "oncomplete", "DestroySelf"));
		}
	}

	void DestroySelf ()
	{
		Destroy (this.gameObject);
	}
}
