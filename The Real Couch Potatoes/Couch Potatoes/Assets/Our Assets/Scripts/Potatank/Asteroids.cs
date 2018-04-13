using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

	public float x, y, z;

	// Use this for initialization
	void Start () 
	{
		x = Random.Range (0f, 1f);
		y = Random.Range (0f, 1f);
		z = Random.Range (0f, 1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		this.transform.Rotate(new Vector3(x, y, z));
		this.transform.Translate(Vector3.left * .5f, Space.World);
	}
}
