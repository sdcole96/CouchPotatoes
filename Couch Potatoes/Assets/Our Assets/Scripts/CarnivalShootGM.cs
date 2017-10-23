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

	public bool phase1 = true;
	public bool phase2 = false;
	public bool phase3 = false;


	// Use this for initialization
	void Start () 
	{
		Debug.Log (Input.GetJoystickNames().Length);

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
		if (phase1) 
		{
			startTime -= Time.deltaTime;
			timerText.text = Mathf.Round (startTime).ToString ();
			if (startTime <= 0) 
			{
				foreach (CarnivalPlayerController player in players) 
				{
					player.enabled = true;
				}

				phase1 = false;
				phase2 = true;
			}
		} 
		else if (phase2) 
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

				phase2 = false;
				phase3 = true;
			}
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
		for (int i = 0; i < playerAmount; i++) 
		{
			GameObject player = Instantiate (playerPrefab, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);
			player.name ="Player " + i.ToString ();
			player.GetComponent<Renderer> ().material = playerMaterials [i];
			CarnivalPlayerController cpc = player.GetComponent<CarnivalPlayerController> ();
			cpc.playerNum = i + 1;
			players.Add(cpc);
			cpc.enabled = false;
		}
	}
}
