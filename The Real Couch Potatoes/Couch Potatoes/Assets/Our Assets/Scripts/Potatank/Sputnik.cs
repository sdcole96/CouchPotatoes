﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sputnik : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		this.transform.Rotate(Vector3.down * 5 * Time.deltaTime);
	}
}
