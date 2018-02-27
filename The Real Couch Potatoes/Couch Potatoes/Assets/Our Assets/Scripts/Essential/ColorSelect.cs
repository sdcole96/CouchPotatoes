using System.Collections;
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
		//ps = GameObject.Find ("Main Camera").GetComponent<PlayerSelect> (); 
		//taterSprite = (Image) ps.spriteImages[playerNum];
	}
	/*
	// Update is called once per frame
	void Update () 
	{
		leftStick = GamePad.GetAxis(CAxis.LX, controllerNum);

		// Goes right
		if(!held && leftStick>0.2f)
		{
			ChangeSprite(1);
			held = true;
			Debug.Log ("Went right");
		}
		// Goes Left
		else if(!held && leftStick<-0.2f)
		{
			ChangeSprite(-1);
			held = true;
			Debug.Log ("Went left: ");
		}
		// Resets when at stand still
		else
		{
			held = false;
			Debug.Log(held);
		}

		//when a button is pressed, change all other sprites
		if (GamePad.GetButton (CButton.A, controllerNum) || GamePad.GetButton (PSButton.Cross, controllerNum)) 
		{
			//set color of player
			
			//remove current sprite from remaining sprites
			ps.remainingSprites.Remove((taterSprite.sprite, taterSprite.animator));
			taterSprite.enabled = false;
			//change all other players sprites
			for(Image im in ps.spriteImages)
			{
				if(im != taterSprite)
					taterSprite.ChangeSprite(0);
			}
			
		}
	}

	// Changes the color of the sprite the player is selecting
	public void ChangeSprite(int direction)
	{
		int currentIndex = ps.remainingSprites.IndexOf (taterSprite.sprite);
		currentIndex -= direction;
		if(currentIndex < 0)
		{
			currentIndex = ps.remainingSprites.Count;
		}

		taterSprite.sprite = (Sprite) ps.remainingSprites [currentIndex].Item1;
		taterSprite.animator = (Animator) ps.remainingSprites [currentIndex].Item2;
	}
	*/
}
