
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	private GameObject myHUD;
	public float raycast = .898f;
	public float speed;
	public int jumpForce = 300;
	public float gravity;
	public Rigidbody rb;
	public float distToGround;
	private Animator anim;
	bool togglePunch = false;
    private float strength;
	public bool speedPowerOn = false;
	public bool stunned = false;


	public int playerNum = -1;
    public PlayerIndex controllerNum;
	public XboxController gamepad = new XboxController ();
	public bool airbourne = false;

	// Use this for initialization
	void Start () 
	{
		rb = this.GetComponent<Rigidbody> ();
		gamepad.playerNum = playerNum;
		myHUD = (GameObject)GameObject.FindGameObjectsWithTag ("P"+(this.playerNum).ToString() +"HUD").GetValue(0);
        strength = this.transform.Find("Skeleton/Left").GetComponent<Punch>().force;
        anim = GetComponent<Animator> ();
		Physics.gravity = new Vector3(0, gravity, 0);


		distToGround = this.GetComponent<Collider> ().bounds.extents.y;


		if (Application.platform == RuntimePlatform.OSXPlayer) 
		{
			gamepad.isMac = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		airbourne = Physics.Raycast(transform.position, - Vector3.up, raycast);
        Vector2 movement = GamePad.GetLeftStick(controllerNum);
		if (!stunned) {
			if (!speedPowerOn)
			{
				rb.AddForce (movement.x * speed, 0, -movement.y * speed);
			} 
		} 
		else
		{
			StartCoroutine (getStunned ());
		}

		if((GamePad.GetButton(CButton.A, controllerNum) || GamePad.GetButton(PSButton.Cross, controllerNum)) && isGrounded())
        { 
			jump ();
			airbourne = true;
		} 

	
		if((GamePad.GetButton(CButton.B, controllerNum) || GamePad.GetButton(PSButton.Circle, controllerNum)) && !isPunching())
		{
			if (!stunned) 
			{
				if (togglePunch) 
				{
					this.transform.Find ("Skeleton/Left").GetComponent<Animator> ().Play ("LeftPunch");
					togglePunch = !togglePunch;
				} else 
				{
					this.transform.Find ("Skeleton/Right").GetComponent<Animator> ().Play ("RightPunch");
					togglePunch = !togglePunch;
				}
			}
		}

	}

	IEnumerator getStunned()
	{
		stunned = true;
		StartCoroutine (flicker ());
		yield return new WaitForSeconds (1f);
		stunned = false;
	}

	IEnumerator flicker()
	{
		Transform t = gameObject.transform.GetChild(0);
		MeshRenderer m0 = t.GetChild (0).GetComponent<MeshRenderer> ();
		MeshRenderer m1 = t.GetChild (1).GetComponent<MeshRenderer> ();
		MeshRenderer m2 = t.GetChild (2).GetComponent<MeshRenderer> ();
		MeshRenderer m3 = t.GetChild (3).GetComponent<MeshRenderer> ();
		MeshRenderer m4 = t.GetChild (4).GetComponent<MeshRenderer> ();
		while (stunned != false) 
		{
			yield return new WaitForSeconds (.1f);
			m0.enabled = !m0.enabled;
			m1.enabled = !m1.enabled;
			m2.enabled = !m2.enabled;
			m3.enabled = !m3.enabled;
			m4.enabled = !m4.enabled;
		}
		m0.enabled = true;
		m1.enabled = true;
		m2.enabled = true;
		m3.enabled = true;
		m4.enabled = true;
	
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
		if (isGrounded ()) {
			rb.AddForce (new Vector3 (0, jumpForce, 0));
		}
	}
		
		
	public bool isGrounded()
	{
		return airbourne;
	}

	IEnumerator powerUpTimer(string powerUpName)
	{
		yield return new WaitForSeconds(10);
		switch (powerUpName) 
		{
		case "Strength":
			{
				myHUD.transform.GetChild (3).gameObject.SetActive (true);
				this.transform.Find ("Skeleton").GetComponent<punchCollider>().force /= 2;
				this.transform.Find ("Skeleton/Left/Orange").gameObject.SetActive (false);
				toggleFireHands (false);
				break;
			}
		case "Speed":
			{
				speedPowerOn = false;
				myHUD.transform.GetChild (4).gameObject.SetActive (true);
				this.transform.Find ("Skeleton/Lightning").GetComponent<ParticleSystem> ().gameObject.SetActive (false);
				speed = speed + 10;
				break;
			}
		default:
			{
				break;
			}
		}
	}

	public void toggleFireHands(bool b)
	{
		this.transform.Find ("Skeleton/Left/Orange").gameObject.SetActive (b);
		this.transform.Find ("Skeleton/Left/Yellow").gameObject.SetActive (b);
		this.transform.Find ("Skeleton/Left/Red").gameObject.SetActive (b);
		this.transform.Find ("Skeleton/Right/Orange").gameObject.SetActive (b);
		this.transform.Find ("Skeleton/Right/Yellow").gameObject.SetActive (b);
		this.transform.Find ("Skeleton/Right/Red").gameObject.SetActive (b);
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
					myHUD.transform.GetChild (3).gameObject.SetActive (false);
					this.transform.Find ("Skeleton").GetComponent<punchCollider>().force *= 2;  
					toggleFireHands (true);
                    Destroy (c.gameObject);
					break;
				}
			case "Speed":
				{
					speedPowerOn = true;
					myHUD.transform.GetChild (4).gameObject.SetActive (false);
					speed = speed + 10;
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
