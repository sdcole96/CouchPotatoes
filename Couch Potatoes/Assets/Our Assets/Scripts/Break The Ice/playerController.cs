
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float speed = 50.0f;
	public int jumpForce = 300;
	public float gravity;
	public Rigidbody rb;
	public float distToGround;
	public int force = 500000;
	private Animator anim;
	bool togglePunch = false;
    private float strength;


	public int playerNum = -1;
	public XboxController gamepad = new XboxController ();

	// Use this for initialization
	void Start () 
	{
        strength = this.transform.Find("Skeleton/Left").GetComponent<Punch>().force;
        anim = GetComponent<Animator> ();
		Physics.gravity = new Vector3(0, gravity, 0);
		rb = GetComponent<Rigidbody> ();
		distToGround = this.GetComponent<Collider> ().bounds.extents.y;
		gamepad.playerNum = playerNum;
		if (Application.platform == RuntimePlatform.OSXPlayer) 
		{
			gamepad.isMac = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		//var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		var xIn = gamepad.getAxisX(ButtonQuery.Hold);
		var zIn = -gamepad.getAxisY (ButtonQuery.Hold);

		var x =  xIn * Time.deltaTime * speed;
		var z = zIn * Time.deltaTime * speed;

		if (Mathf.Abs (xIn) > .075f || Mathf.Abs (zIn) > .075f) 
		{
			transform.Translate(x, 0, z);
		}
			


		if(gamepad.getAButton(ButtonQuery.Down)||Input.GetKeyDown(KeyCode.Space))
		{ 
			if (isGrounded())
			{
				jump ();
			}
		} 

	
		if(gamepad.getBButton(ButtonQuery.Down) && !isPunching())
		{
			if (togglePunch)
			{
				this.transform.Find ("Skeleton/Left").GetComponent<Animator> ().Play ("LeftPunch");
				togglePunch = !togglePunch;
			} 
			else 
			{
				this.transform.Find ("Skeleton/Right").GetComponent<Animator> ().Play ("RightPunch");
				togglePunch = !togglePunch;
			}
		}

	}

	public bool isPunching()
	{
		if (this.transform.Find("Skeleton/Left").GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("LeftPunch")) 
		{
			return true;
		} 
		else if (this.transform.Find("Skeleton/Right").GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("RightPunch"))
		{
			return true;
		}
		return false;
	}
		

	private void jump()
	{
		rb.AddForce (new Vector3 (0, jumpForce, 0));
	}
		
		
	public bool isGrounded()
	{
		return Physics.Raycast(transform.position, - Vector3.up, 1);

	}

	IEnumerator powerUpTimer(string powerUpName)
	{
		yield return new WaitForSeconds(10);
		switch (powerUpName) 
		{
		case "Strength":
			{
				this.transform.Find ("Skeleton/Left").GetComponent<Punch> ().force /= 2;
				this.transform.Find ("Skeleton/Right").GetComponent<Punch> ().force /= 2;
				break;
			}
		case "Speed":
			{
				speed = 50;
				break;
			}
		default:
			{
				break;
			}
		}
	}
	//deal with powerups
	public void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Powerup") 
		{
			StartCoroutine (powerUpTimer (c.gameObject.name));
			switch (c.gameObject.name) 
			{
			case "Strength":
				{
                        this.transform.Find("Skeleton/Left").GetComponent<Punch>().force *= 2;
                        this.transform.Find("Skeleton/Right").GetComponent<Punch>().force *= 2;
                    Destroy (c.gameObject);
					break;
				}
			case "Speed":
				{
					speed = 100;
					Destroy (c.gameObject);
					break;
				}
			default:
				{
					Destroy (c.gameObject);
					break;
				}
			}
		}
	}
}

enum TestMode
{
	Keyboard,
	MacController,
	WindowsController
}
