using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarnivalShootGM : MonoBehaviour {

	// Player scores
	public int p1Score = 0;
	public int p2Score = 0;
	public int p3Score = 0;
	public int p4Score = 0;

	public Text p1Text;
	public Text p2Text;
	public Text p3Text;
	public Text p4Text;

	// Timer
	public float timer;

	public Text timerText;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void UpdatePlayerScore(int playerNum, int points)
	{
		switch (playerNum) 
		{
		case 1:
			p1Score += points;
			p1Text.text = "Player 1: " + p1Score.ToString ();
			break;
		case 2:
			p2Score += points;
			p2Text.text = "Player 2: " + p2Score.ToString ();
			break;
		case 3:
			p3Score += points;
			p3Text.text = "Player 3: " + p3Score.ToString ();
			break;
		case 4:
			p4Score += points;
			p4Text.text = "Player 4: " + p4Score.ToString ();
			break;
		}
	}
}
