using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
    public bool isPaused = false;
	private GameObject[] playerList;
	// Use this for initialization
	void Start () 
	{
		playerList = GameObject.FindGameObjectsWithTag ("RotationSkeleton");
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Escape) || GamePad.GetButton(CButton.Start) || GamePad.GetButton(PSButton.Start)) && isPaused == false)
        {
            Pause();
        }
        else if ((GamePad.GetButton(CButton.Start) || GamePad.GetButton(PSButton.Start)) && isPaused)
        {
            Pause();
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
        if (isPaused==false)
        {
            isPaused = true;
            foreach (GameObject player in playerList)
            {
                player.GetComponent<rotationController>().enabled = false;
            }
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            foreach (GameObject player in playerList)
            {
                player.GetComponent<rotationController>().enabled = true;
            }
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
	}
}
