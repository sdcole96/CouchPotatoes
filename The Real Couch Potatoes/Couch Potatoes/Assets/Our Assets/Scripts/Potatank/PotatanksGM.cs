using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatanksGM : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject[] playerSpawns;
    public List<GameObject> players;
	public GameObject[] huds;
	public TankController playerControllers;
	public bool gameOver = false;   
	public int playersLeft;
	public bool isDev = false;
	public Text title;
	public int winningIndex;

    public bool alreadyCheckedWinner;


	// Use this for initialization
	void Start () 
	{
		playersLeft = GameMaster.activePlayers.Count;
        alreadyCheckedWinner = false;
		StartCoroutine (turnOffTitle ());
		if (!isDev) 
		{
			for (int i = 0; i < 4; i++)
			{
				huds [i].SetActive (false);
				playerSpawns [i].SetActive (false);
			}
			for (int i = 0; i < GameMaster.activePlayers.Count; i++)
			{
				huds [i].SetActive (true);
				playerSpawns [i].SetActive (true);
                players.Add(playerSpawns[i]);
				playerSpawns[i].gameObject.GetComponent<TankController>().pi = GameMaster.activePlayers[i].GetPIndex();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!alreadyCheckedWinner && players.Count == 1 && playersLeft == 1 && !gameOver) 
		{
            alreadyCheckedWinner = true;
            winningIndex = players[0].GetComponent<TankController>().playerNum;
            Debug.Log(winningIndex);
            gameOver = true;
            StartCoroutine (changeScene (5.0f));

            
            
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

			TankController tc = player.GetComponent<TankController> ();
			//tc.playerNum = i + 1;
			tc.pi = GameMaster.activePlayers [i].GetPIndex();
			//playerControllers.Add(tc);
			tc.enabled = false;
		}
	}

	IEnumerator changeScene(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ChangeScene cs = GameObject.Find("Main Camera"). GetComponent<ChangeScene>();
		cs.LoadSceneMM ();
	}

	IEnumerator turnOffTitle()
	{
        foreach (GameObject ps in playerSpawns) {
            ps.GetComponent<TankController>().enabled = false;
        }
		yield return new WaitForSeconds (5f);
        foreach (GameObject ps in playerSpawns)
        {
            ps.GetComponent<TankController>().enabled = true;
        }
        title.enabled = false;

	}
}
