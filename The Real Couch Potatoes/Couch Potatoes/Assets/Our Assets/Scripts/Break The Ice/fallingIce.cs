using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fallingIce : MonoBehaviour {

	public int seconds = 6;
	public int i = 0;
	public GameObject[] players;
	public Camera mainCamera;
	public Vector3 cam;
	public float t = 0;
	public bool gameOver = false;
	public bool penguinDrop = true;
	public GameObject middleText;
    public GameObject gameOverText;
	public float x;
	public float z;

	public GameObject penguinPrefab;

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
		cam = mainCamera.transform.position;
		players = new GameObject[4];
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

	public void penguins(GameObject player)
	{
		int pNum = player.GetComponent<playerController> ().playerNum;

		switch (pNum) 
		{
			case 1:
				{
				penguinPrefab = GameObject.Find ("PenguinRed");
				break;
				}
			case 2:
				{
					penguinPrefab = GameObject.Find ("PenguinGreen");
					break;
				}
			case 3:
				{
					penguinPrefab = GameObject.Find ("PenguinBlue");
					break;
				}
			case 4:
				{
					penguinPrefab = GameObject.Find ("PenguinYellow");
					break;
				}
		}
			
		foreach (GameObject ice in GameObject.FindGameObjectsWithTag("Floor")) 
		{
			GameObject temp = Instantiate (penguinPrefab, new Vector3 (ice.transform.position.x + 4.35f, 20, ice.transform.position.z - 12.1f), new Quaternion ());
			temp.AddComponent<Rigidbody> ();
			temp.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		}
		
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


		if (players.Length <= 1) 
		{
			
			if(t == 0)
			{
                //gameOverText.GetComponent<Text>().enabled = true;
                gameOverText.GetComponent<Text> ().text = "Game Over";
				if (players.Length == 0)
				{
					
					StartCoroutine (changeScene (3.0f));
				} 
				else 
				{
					GameObject winner = players [0];
					GameObject g = GameObject.Find ("CutsceneCam");

					if (t == 0)
					{
						x = players [0].transform.position.x;
						z = players [0].transform.position.z;
					}
					

					g.transform.position = Vector3.Lerp (g.transform.position, new Vector3(x,5f,z), t);
					StartCoroutine (changeScene (6.0f));
					if (t == 0) 
					{
						penguins (winner);
					}
					t += .01f;
				}
			}
			gameOver = true;
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

			yield return new WaitForSeconds (seconds);
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
				ice.tag = "Falling";
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

			players[i] = player;
        }
	}

	IEnumerator changeScene(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ChangeScene cs = GameObject.Find("Main Camera"). GetComponent<ChangeScene>();
		cs.LoadSceneMM ();
	}


}
