using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
	// speed and angle
	public float rotationSpeed = 1.0f;
	public float rotationAngle = 90.0f;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.left * Time.deltaTime);
		Quaternion target = Quaternion.Euler (rotationAngle, 0, 0);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * rotationSpeed);
	}
}
