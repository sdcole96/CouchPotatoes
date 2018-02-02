using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
    public bool isPaused = false;
    // Below variables are for fixing pause screen flicker
    public float coolDownPeriod = 0.1f;
    private bool inCooldown = false; // For checking if you are currently in 'cooldown mode'
    // For disabling player controllers
    public bool carnivalGame;
    public bool iceGame;
    public List<MonoBehaviour> controllerList;

    // Use this for initialization
    void Start () 
	{
        /*
        GameObject[] playerList = GameObject.FindGameObjectsWithTag ("Player");
        foreach (GameObject player in playerList)
        {
            if (carnivalGame)
                controllerList.Add(player.GetComponent<CarnivalPlayerController>());
            else if (iceGame)
                controllerList.Add(player.GetComponent<playerController>());
        } */
		
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
        if (isPaused==false && !inCooldown) // If the game is not paused, pause game
        {
            isPaused = true;
            /*
            foreach (MonoBehaviour controllerScript in controllerList)
            {
                controllerScript.enabled = false;
            } */
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine("cooldownMode");
        }
        else if (!inCooldown) // If the game is already paused, resume game
        {
            isPaused = false;
            /*
            foreach (MonoBehaviour controllerScript in controllerList)
            {
                controllerScript.enabled = true;
            }
            */
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine("cooldownMode");
        }
	}
    IEnumerator cooldownMode() // Cooldown period before the player can pause/unpause the game after previously pausing/unpausing it.
    {
        inCooldown = true;
        yield return new WaitForSecondsRealtime(coolDownPeriod);
        inCooldown = false;
    }

}
