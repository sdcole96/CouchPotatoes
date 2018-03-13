using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatanksGM : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject[] playerSpawns;
	public TankController playerControllers;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
}
