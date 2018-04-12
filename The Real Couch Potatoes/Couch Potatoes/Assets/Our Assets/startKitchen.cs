using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startKitchen : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] playerObjects;
	public GameObject playerPrefab;
	public GameObject[] playerSpawns = new GameObject[4];
	public Material[] playerMaterials = new Material[4];

	// Use this for initialization
	void Start () 
	{
		CreatePlayers (Input.GetJoystickNames ().Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreatePlayers(int playerAmount)
	{
		for (int i = 0; i < playerAmount; i++) 
		{
			GameObject player = Instantiate (playerPrefab, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);
			player.transform.GetChild (0).GetComponent<rotationController> ().controllerNum = GameMaster.activePlayers[i].GetPIndex();
			player.name ="Player " + (i+1).ToString ();
			foreach (MeshRenderer meshes in player.GetComponentsInChildren<MeshRenderer> ()) 
			{
				if (meshes.name != "Eye") 
				{
					meshes.material = playerMaterials [i];
				}
			}
			playerController pc = player.GetComponent<playerController> ();
			pc.controllerNum = GameMaster.activePlayers[i].GetPIndex();
			pc.playerNum = i + 1;

			players[i] = player;
		}
	}
}
