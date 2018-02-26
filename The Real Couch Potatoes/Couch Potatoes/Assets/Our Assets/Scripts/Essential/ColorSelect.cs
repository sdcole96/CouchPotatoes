﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelect : MonoBehaviour 
{
	private float leftStick;
	private PlayerSelect ps;
	public bool held = false;
	public Image taterSprite;
	public PlayerIndex controllerNum;
	public int playerNum;

	// Use this for initialization
	void Start () 
	{
		ps = GameObject.Find ("Main Camera").GetComponent<PlayerSelect> (); 
		taterSprite = (Image) ps.remainingSprites[playerNum-1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		leftStick = GamePad.GetAxis(CAxis.LX, controllerNum);

		// Goes right
		if(!held && leftStick>0)
		{
			ChangeSprite(1);
			held = true;
		}
		// Goes Left
		else if(!held && leftStick<0)
		{
			ChangeSprite(-1);
			held = true;
		}
		// Resets when at stand still
		else
		{
			held = false;
		}

		//when a button is pressed, change all other sprite
		if (GamePad.GetButton (CButton.A, controllerNum) || GamePad.GetButton (PSButton.Cross, controllerNum)) 
		{
			//set color of player
			//remove current sprite from remaining sprites
			//change all other players sprites
		}
	}

	// Changes the color of the sprite the player is selecting
	public void ChangeSprite(int direction)
	{
		int currentIndex = ps.remainingSprites.IndexOf (taterSprite);
		currentIndex -= direction;
		if(currentIndex < 0)
		{
			currentIndex = ps.remainingSprites.Count;
		}

		taterSprite = (Image) ps.remainingSprites [currentIndex];
	}
}
