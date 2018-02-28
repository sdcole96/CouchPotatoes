using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour {

	public bool cutsceneOver;

	// Use this for initialization
	void Start () {
		
		while (GameObject.Find ("Penguin") != null) 
		{
			this.gameObject.SetActive (false);	
		}
		this.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
