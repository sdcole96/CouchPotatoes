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

    public Text[] PlayerScoreText;

    public Image backgroundBar;
	public GameObject instruction;
	public GameObject pauseMenu;

    public Text winnerScore;

	public GameObject[] playerScoreBoxes;

	public GameObject curtain1;
	public GameObject curtain2;
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
        backgroundBar.enabled = false;
		pauseMenu.SetActive (false);
        for (int i = 0; i < GameMaster.activePlayers.Count; i++)
        {
			Debug.Log(GameMaster.activePlayers[i].GetPScore());
        }
		foreach (GameObject scoreBox in playerScoreBoxes) 
		{
			scoreBox.SetActive (false);
		}

		CreatePlayers (GameMaster.activePlayers.Count);

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
		if (phase == 0) 
		{
			if (GamePad.GetButton (CButton.Start) || GamePad.GetButton (PSButton.Start)) 
			{
				instruction.SetActive(false);
				StartCoroutine (openCurtains ());
				++phase;
			}
		}
		else if (phase == 1) 
		{
			for (int i = 0; i < GameMaster.activePlayers.Count; i++) 
			{
				playerScoreBoxes [i].SetActive (true);
			}
			startTime -= Time.deltaTime;
			timerText.text = Mathf.Round (startTime).ToString ();
			if (startTime <= 0) 
			{
				foreach (CarnivalPlayerController player in players) 
				{
					player.enabled = true;
				}
                pauseMenu.SetActive(true);
                ++phase;
			}
		} 
		else if (phase == 2) 
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

				++phase;
			}
		}
		else if (phase == 3)
		{
            AddWinningPoints();
			++phase;
		}
		else if(phase == 4)
		{
            //backgroundBar.enabled = true;
            for (int i = 0; i < GameMaster.activePlayers.Count; i++)
            {
				//PlayerScoreText[i].text = "Player " + (i + 1) + ": " + GameMaster.activePlayers[i].GetPScore();
            }
            StartCoroutine (changeScene (5.0f));
			++phase;
		}

	}

	IEnumerator openCurtains()
	{
		float i = 0;
		yield return new WaitForSeconds (1f);
		while (i < 5) 
		{
			i += .1f;
			yield return new WaitForSeconds (.1f);
			curtain1.gameObject.transform.position = curtain1.gameObject.transform.position + new Vector3 (i, 0, 0);
			curtain2.gameObject.transform.position = curtain2.gameObject.transform.position + new Vector3 (-i, 0, 0);
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
		GameObject centerScreen = GameObject.Find("Main Camera");
		for (int i = 0; i < playerAmount; i++) 
		{
			GameObject player = Instantiate (playerPrefab, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);
			player.name ="Player " + (i+1).ToString ();
			player.transform.parent = centerScreen.transform;
            SpriteRenderer[] sr = player.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer s in sr)
            {
                s.color = colors[i];
            }

			CarnivalPlayerController cpc = player.GetComponent<CarnivalPlayerController> ();
			cpc.playerNum = i + 1;
			cpc.controllerNum = GameMaster.activePlayers [i].GetPIndex();
			players.Add(cpc);
			cpc.enabled = false;
		}
	}

	IEnumerator changeScene(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ChangeScene cs = GameObject.Find("Main Camera"). GetComponent<ChangeScene>();
		cs.LoadSceneMM ();
	}

    public void AddWinningPoints()
    {
        int[] playerScores = { p1Score, p2Score, p3Score, p4Score };
        int[] winningOrder = new int[playerScores.Length];
        Array.Copy(playerScores, winningOrder, playerScores.Length);
        Array.Sort(winningOrder);
        Array.Reverse(winningOrder);
        winnerScore.text = "Player " + (Array.IndexOf(playerScores, winningOrder[0]) + 1) + " Wins!\n" + string.Format("{0:n0}", winningOrder[0]) + " Points!";
        winnerScore.enabled = true;

        int winningPoints = GameMaster.activePlayers.Count;

        //for (int i = 0; i < winningOrder.Length; i++)
        //{
        //    for (int j = 0; j < playerScores.Length; j++)
        //    {
        //        if (winningOrder[i] == playerScores[j])
        //        {
        //            Debug.Log(j);
        //            GameMaster.activePlayers[j].playerScore += winningPoints;
        //            winningPoints--;
        //            Debug.Log("Player" + (j+1) + ": " + GameMaster.activePlayers[j].playerScore);
        //            break;
        //        }
        //    }
        //}
    }
}
