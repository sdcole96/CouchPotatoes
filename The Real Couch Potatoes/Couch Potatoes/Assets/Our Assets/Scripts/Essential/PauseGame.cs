using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	private GameObject[] playerList;
	// Use this for initialization
	void Start () 
	{
		playerList = GameObject.FindGameObjectsWithTag ("RotationSkeleton");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	public void Quit()
	{
		Time.timeScale = 1;
		ChangeScene cs = new ChangeScene ();
		cs.LoadSceneMM ();
	}

	public void Pause()
	{
		if (canvas.gameObject.activeInHierarchy == false) 
		{
			foreach (GameObject player in playerList) 
			{
				player.GetComponent<rotationController> ().enabled = false;
			}
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		} 
		else
		{
			foreach (GameObject player in playerList) 
			{
				player.GetComponent<rotationController> ().enabled = true;
			}
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
