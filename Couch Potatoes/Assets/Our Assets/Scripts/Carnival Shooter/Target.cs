﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
	// speed and angle
	public float rotationSpeed = 2.0f;
	public float rotationAngle = -90.0f;
	public bool hit = false;

	public int pointValue;

	public GameObject pole;
	public GameObject ship;
	public MeshRenderer target;

	public Material[] playerColors;

	public float originalY = 180f;
	public float originalZ = 0f;
	public float speed = 1f;
	public bool goRight = false;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (goRight)
        {
			pole.transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		else
		{
			pole.transform.Translate (Vector3.left * Time.deltaTime * speed);
		}

		if (hit) 
		{
			Quaternion targetRotation = Quaternion.Euler (rotationAngle, originalY, originalZ);
			ship.transform.rotation = Quaternion.Slerp (ship.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);	
		}
	}

	public void ChangeTargetColor(int playerNum)
	{
		target.material = playerColors [playerNum-1];
	}
}
