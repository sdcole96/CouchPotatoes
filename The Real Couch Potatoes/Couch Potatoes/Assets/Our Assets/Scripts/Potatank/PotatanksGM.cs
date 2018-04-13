using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatanksGM : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject[] playerSpawns;
	public TankController playerControllers;
	public bool gameOver = false;   
	public int playersLeft;
	public bool isDev = false;


	// Use this for initialization
	void Start () 
	{
		playersLeft = GameMaster.activePlayers.Count;
		if (!isDev) 
		{
			for (int i = 0; i < 4; i++)
			{
				playerSpawns [i].SetActive (false);
			}
			for (int i = 0; i < GameMaster.activePlayers.Count; i++)
			{
				playerSpawns [i].SetActive (true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playersLeft == 1) 
		{
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
}
