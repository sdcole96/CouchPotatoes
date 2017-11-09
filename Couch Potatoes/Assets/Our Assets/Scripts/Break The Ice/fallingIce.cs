using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingIce : MonoBehaviour {

	public int seconds = 5;
	public int i = 0;
	public GameObject[] players;
	public Camera mainCamera;
	public Vector3 camera;
	private float t;
	private bool gameOver;


	public GameObject[] playerObjects;
	public GameObject playerPrefab;
	public GameObject[] playerSpawns = new GameObject[4];
	public Material[] playerMaterials = new Material[4];



	// Use this for initialization
	void Start () 
	{
		camera = mainCamera.transform.position;
		StartCoroutine (dropIce(seconds));
		t = 0;
		gameOver = false;

		CreatePlayers (Input.GetJoystickNames ().Length);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (players.Length == 1) 
		{
			gameOver = true;
			mainCamera.transform.position = Vector3.Lerp (camera, players [0].transform.position+new Vector3(0,3,-3), t);
			t += .01f;
			StartCoroutine (changeScene (3.0f));
		}
	}

	void destroyMe()
	{
		
	}
		

	private IEnumerator dropIce(float waitTime)
	{
		int childCount = transform.childCount;
		while (childCount > 2) 
		{
			childCount = transform.childCount;

			yield return new WaitForSeconds (waitTime);

			players = GameObject.FindGameObjectsWithTag("Player");
			if (players.Length != 1) {
				int rand = Random.Range (0, players.Length);
				GameObject g = findClosestIce (players [rand]);

				//Transform ice = transform.GetChild(rand).GetChild(0);
				Animator iceAnim = g.GetComponent<Animator> ();
				iceAnim.Play ("fallingIce");
			}
		}
	}

	public GameObject findClosestIce(GameObject g)
	{
		GameObject[] ice;
		ice = GameObject.FindGameObjectsWithTag ("Floor");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = g.transform.position;
		foreach (GameObject i in ice)
		{
			Vector3 diff = i.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = i;
				distance = curDistance;
			}
		}
		return closest;
	}

	public void CreatePlayers(int playerAmount)
	{
		for (int i = 0; i < playerAmount; i++) 
		{
			GameObject player = Instantiate (playerPrefab, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);
			player.transform.GetChild (0).GetComponent<rotationController> ().playerNum = i + 1;
			player.name ="Player " + (i+1).ToString ();
			foreach (MeshRenderer meshes in player.GetComponentsInChildren<MeshRenderer> ()) 
			{
				meshes.material = playerMaterials [i];
			}
			playerController cpc = player.GetComponent<playerController> ();
			cpc.playerNum = i + 1;

			//players.Add(cpc);
		}
	}

	IEnumerator changeScene(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ChangeScene cs = new ChangeScene ();
		cs.LoadSceneMM ();
	}
}
