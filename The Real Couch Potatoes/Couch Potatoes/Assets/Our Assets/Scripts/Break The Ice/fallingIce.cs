using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingIce : MonoBehaviour {

	public int seconds = 6;
	public int i = 0;
	public GameObject[] players;
	public Camera mainCamera;
	public Vector3 camera;
	private float t;
	private bool gameOver;

	public bool debugMode;
	public GameObject[] playerObjects;
	public GameObject playerPrefab;
	public GameObject[] playerSpawns = new GameObject[4];
	public Material[] playerMaterials = new Material[4];

    public GameObject hud3;
    public GameObject hud4;



	// Use this for initialization
	void Start () 
	{
		camera = mainCamera.transform.position;
		StartCoroutine (dropIce(seconds));
		t = 0;
		gameOver = false;
		int i = 0;
		if (debugMode) 
		{
			i = 1;
		}
		CreatePlayers (Input.GetJoystickNames ().Length + i);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (players.Length < 4)
        {
            Destroy(hud4);
            if (players.Length < 3)
            {
                Destroy(hud3);
            }
        }
        if (players.Length == 1) 
		{

			gameOver = true;
			GameObject g = GameObject.Find ("CutsceneCam");
			g.transform.position = Vector3.Lerp (g.transform.position, players [0].transform.position+new Vector3(0,3,-3), t);
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
			seconds = 3;
			players = GameObject.FindGameObjectsWithTag("Player");
			if (players.Length > 1) 
			{
				int rand = Random.Range (0, players.Length);
				ArrayList closeIce = findClosestIce (players [rand]);

				int rand2 = Random.Range (0, closeIce.Count);
				GameObject ice = (GameObject)closeIce [rand2];

				Animator iceAnim = ice.GetComponent<Animator> ();
				iceAnim.Play ("fallingIce");
				ice.tag = "falling";
			}
		}
	}

	public ArrayList findClosestIce(GameObject g)
	{
		GameObject[] ice;
		ice = GameObject.FindGameObjectsWithTag ("Floor");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = g.transform.position;

		ArrayList closeIce = new ArrayList ();
		foreach (GameObject i in ice)
		{
			Vector3 diff = i.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < 50)
			{
				closeIce.Add (i);
                Debug.Log("Ice Added");
			}
		}
        if(closeIce.Count == 0)
        {
            closeIce.Add(GameObject.FindGameObjectWithTag("Floor"));
        }
		return closeIce;
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
