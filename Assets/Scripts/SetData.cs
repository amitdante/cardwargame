using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetData : MonoBehaviour
{
	public Text powerText;
	[HideInInspector]
	public int power;
	public bool random;
	// Use this for initialization
	void Start ()
	{
		power = 3;
		if (random)
			power = UnityEngine.Random.Range (1, 11);
		
		powerText.text = power.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}
