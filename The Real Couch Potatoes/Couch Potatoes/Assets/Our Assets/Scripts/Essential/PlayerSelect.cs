﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public int playerNum = -1;
	public Rigidbody[] potatoes;
    public Text playerJoinText; // Player has joined the game textbox
    public Text startText; // Press start to begin textbox

	public bool playerJoined1 = true;
	public bool playerJoined2 = true;
	public bool playerJoined3 = true;
	public bool playerJoined4 = true;
	public bool playerJoined5 = true;
	public bool playerJoined6 = true;
	public bool playerJoined7 = true;
	public bool playerJoined8 = true;

    //public XboxController gamepad = new XboxController();

    private bool isPressStartCoroutineStarted = false;

    // Use this for initialization
    void Start ()
    {
//        if (Application.platform == RuntimePlatform.OSXPlayer)
//        {
//            gamepad.isMac = true;
//        }
		GamePadState state1 = GamePad.GetState(PlayerIndex.One);
		GamePadState state2 = GamePad.GetState(PlayerIndex.Two);
		GamePadState state3 = GamePad.GetState(PlayerIndex.Three);
		GamePadState state4 = GamePad.GetState(PlayerIndex.Four);
		GamePadState state5 = GamePad.GetState(PlayerIndex.Five);
		GamePadState state6 = GamePad.GetState(PlayerIndex.Six);
		GamePadState state7 = GamePad.GetState(PlayerIndex.Seven);
		GamePadState state8 = GamePad.GetState(PlayerIndex.Eight);


    }
	
	// Update is called once per frame
	void Update ()
    {
//        if (gamepad.getStartButton(ButtonQuery.Down) && GameMaster.activePlayers.Count < 4)
//        {
//
//            playerNum = GameMaster.activePlayers.Count;
//        }
        // Show the "Press Start to begin" text
        if (!isPressStartCoroutineStarted && GameMaster.activePlayers.Count == 2)
        {  
            isPressStartCoroutineStarted = true;
            StartCoroutine("pressStartToBegin");
        }

		if(((GamePad.GetButton(CButton.A, PlayerIndex.One) || GamePad.GetButton(PSButton.Cross, PlayerIndex.One)) && GameMaster.activePlayers.Count < 4) && playerJoined1)
		{
			playerJoined1 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.One);
			GameMaster.activePlayers.Add (newPlayer);
            StartCoroutine(showPlayerJoined(1, Color.red));
			Debug.Log ("Controller 1");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Two) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Two)) && GameMaster.activePlayers.Count < 4) && playerJoined2)
		{
			playerJoined2 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Two);
			GameMaster.activePlayers.Add (newPlayer);
            StartCoroutine(showPlayerJoined(2, Color.green));
            Debug.Log ("Controller 2");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Three) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Three)) && GameMaster.activePlayers.Count < 4) && playerJoined3)
		{
			playerJoined3 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Three);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 3");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Four) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Four)) && GameMaster.activePlayers.Count < 4) && playerJoined4)
		{
			playerJoined4 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Four);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 4");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Five) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Five)) && GameMaster.activePlayers.Count < 4) && playerJoined5)
		{
			playerJoined5 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Five);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 5");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Six) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Six)) && GameMaster.activePlayers.Count < 4) && playerJoined6)
		{
			playerJoined6 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Six);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 6");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Seven) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Seven)) && GameMaster.activePlayers.Count < 4) && playerJoined7)
		{
			playerJoined7 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Seven);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 7");
		}
		else if(((GamePad.GetButton(CButton.A, PlayerIndex.Eight) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Eight)) && GameMaster.activePlayers.Count < 4) && playerJoined8)
		{
			playerJoined8 = false;
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Eight);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 8");
		}
	}

	public void DropTater()
	{
		potatoes[GameMaster.activePlayers.Count].useGravity = true;
	}
    
    IEnumerator showPlayerJoined(int playerNumber, Color colorName)
    {
        //Show text
        playerJoinText.enabled = true;
        playerJoinText.color = colorName;
        playerJoinText.text = "Player #" + playerNumber + " has joined the game";
        // Wait 5 seconds
        yield return new WaitForSeconds(5);
        // Hide Text
        playerJoinText.enabled = false;
    }

    IEnumerator pressStartToBegin()
    {
        while (true)
        {
            startText.enabled = true;
            yield return new WaitForSeconds(0.6f);
            startText.enabled = false;
            yield return new WaitForSeconds(0.6f);
        }
        
    }
}
