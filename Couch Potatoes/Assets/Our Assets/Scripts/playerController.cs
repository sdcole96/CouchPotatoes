
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

	public int playerNum = -1;
	public XboxController gamepad = new XboxController ();

	// Use this for initialization
	void Start () 
	{
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
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && Input.GetMouseButtonDown (0)) {
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
			Debug.Log ("PUNCH");
		}
	}

	private void jump()
	{
		rb.AddForce (new Vector3 (0, jumpForce, 0));
	}
		
	public void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetMouseButtonDown(0)) 
		{
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
			Debug.Log ("PUNCH");
		}
	}
		
	public bool isGrounded()
	{
		return Physics.Raycast(transform.position, - Vector3.up, 1);

	}
}

enum TestMode
{
	Keyboard,
	MacController,
	WindowsController
}
