using System;
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

	public Text winnerScore;

	public GameObject[] playerScoreBoxes;

	public CarnivalSpawner spawners;
	public List<CarnivalPlayerController> players = new List<CarnivalPlayerController> ();
	public GameObject[] playerObjects;

	public GameObject playerPrefab;
	public GameObject[] playerSpawns = new GameObject[4];
	public Material[] playerMaterials = new Material[4];

	// Timer
	public float timeLeft = 30.0f;
	public float startTime = 3.0f;
	public Text timerText;

	public int phase = 0;


	// Use this for initialization
	void Start () 
	{
		winnerScore.enabled = false;

		int i = 0;
		foreach (string name in Input.GetJoystickNames()) 
		{
			Debug.Log ("index " + i + ": "+ name);
			++i;
		}

		foreach (GameObject scoreBox in playerScoreBoxes) 
		{
			scoreBox.SetActive (false);
		}

		CreatePlayers (Input.GetJoystickNames ().Length);

//		playerObjects = GameObject.FindGameObjectsWithTag ("Player");
//		for (int i = 0; i < playerObjects.Length; i++) 
//		{
//			players.Add(playerObjects [i].GetComponent<CarnivalPlayerController> ());
//		}
//
//		foreach (CarnivalPlayerController player in players) 
//		{
//			player.enabled = false;
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (phase==0) 
		{
			startTime -= Time.deltaTime;
			timerText.text = Mathf.Round (startTime).ToString ();
			if (startTime <= 0) 
			{
				foreach (CarnivalPlayerController player in players) 
				{
					player.enabled = true;
				}

				phase++;
			}
		} 
		else if (phase==1) 
		{
			timeLeft -= Time.deltaTime;
			timerText.text = Mathf.Round (timeLeft).ToString ();
			if (timeLeft <= 0) 
			{
				foreach (CarnivalPlayerController player in players) 
				{
					player.enabled = false;
				}

				spawners.enabled = false;

				phase++;
			}
		}
		else if (phase==2)
		{
			int[] playerScores = {p1Score, p2Score, p3Score, p4Score};
			int[] winningOrder = new int[playerScores.Length];
			Array.Copy (playerScores, winningOrder, playerScores.Length);
			Array.Sort (winningOrder);
			Array.Reverse (winningOrder);
			Debug.Log (playerScores [0] + " " + winningOrder [0]);
			winnerScore.text = "Player "+ (Array.IndexOf(playerScores, winningOrder[0])+1) + " Wins!\n" + string.Format ("{0:n0}", winningOrder[0]) + " Points!";
			winnerScore.enabled = true;

            int i = 3;
            foreach (int score in winningOrder)
            {
                if (score == playerScores[0])
                {
                    GameMaster.AddScore(1, i);
                }
                else if (score == playerScores[1])
                {

                }
                else if (score == playerScores[2])
                {

                }
                else if (score == playerScores[1])
                {

                }
            }

			phase++;
		}
		else if(phase==3)
		{
			StartCoroutine (changeScene (3.0f));
			phase++;
		}

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

	public void CreatePlayers(int playerAmount)
	{
		Color[] colors = {Color.red, Color.green, Color.blue, Color.yellow};
		for (int i = 0; i < playerAmount; i++) 
		{
			GameObject player = Instantiate (playerPrefab, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);
			player.name ="Player " + (i+1).ToString ();
			player.GetComponentInChildren<SpriteRenderer> ().color = colors[i];
			CarnivalPlayerController cpc = player.GetComponent<CarnivalPlayerController> ();
			cpc.playerNum = i + 1;
			players.Add(cpc);
			cpc.enabled = false;
			playerScoreBoxes [i].SetActive (true);
		}
	}

	IEnumerator changeScene(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ChangeScene cs = new ChangeScene ();
		cs.LoadSceneMM ();
	}
}
