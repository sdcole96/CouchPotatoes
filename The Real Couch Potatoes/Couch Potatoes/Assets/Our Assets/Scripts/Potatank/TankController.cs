﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	private float rightStick;
	private float leftStick;
	public bool stunned = false;
	public bool canFire = true;
	public bool dead = false;
	public bool rightFire = true;
	public int life = 3;
    public GameObject bullet;
    public GameObject[] firingPoints;
	public GameObject explosion;
	public PlayerIndex pi;
	public PotatanksGM gm;
	public GameObject[] hearts;
	public int playerNum;

	public float trigger = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rightStick = GamePad.GetAxis (CAxis.RX, pi);
		leftStick = GamePad.GetAxis(CAxis.LY, pi);
		if (!stunned) 
		{
			//this.transform.Translate ((-Vector3.forward * rightStick - Vector3.forward * leftStick)*.3f);
			//this.transform.Rotate (Vector3.up, 2 * rightStick - 2 * leftStick);
			this.transform.Translate((-Vector3.forward*leftStick)*.3f);
			this.transform.Rotate(new Vector3(0f,5f*rightStick,0f));
			trigger = GamePad.GetRightTrigger (pi);
			if (canFire && GamePad.GetButton(CButton.RB, pi))
			{
                //Debug.Log("This player num is " + playerNum);
				StartCoroutine (FireRate(1f));
				if (rightFire) 
				{
					Instantiate (bullet, firingPoints [0].transform.position, firingPoints [0].transform.rotation);
					rightFire = false;
				}
				else 
				{
					Instantiate (bullet, firingPoints [1].transform.position, firingPoints [1].transform.rotation);
					rightFire = true;
				}
			}
		}
			


		if (life <= 0 && !dead) 
		{
			stunned = true;
			canFire = false;
			dead = true;
			StartCoroutine (TankDeath ());
		}

        /*
        if (gm.gameOver)
        {
            gm.winningIndex = playerNum;
        }
        */
    }

	public void Hit()
	{
		StartCoroutine (Stun ());
		if (life == 2) 
		{
			hearts [2].SetActive (false);	
		}
		else if (life == 1) 
		{
			hearts [1].SetActive (false);	
		} 
		else 
		{
			hearts [0].SetActive (false);	
		}
	}

	public IEnumerator Stun()
	{
		stunned = true;
		yield return new WaitForSeconds (0.5f);
		stunned = false;
	}

	public IEnumerator FireRate(float seconds)
	{
		canFire = false;
		yield return new WaitForSeconds (seconds);
		canFire = true;
	}

	public IEnumerator TankDeath()
	{
		gm.playersLeft -= 1;
		GameObject exp = Instantiate (explosion, this.gameObject.transform);
		exp.transform.parent = null;
		yield return new WaitForSeconds (0.5f);
        gm.players.Remove(this.gameObject);
		Destroy (this.gameObject);
	}
}
