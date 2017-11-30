using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour 
{
	public float speed = 5f;
	public float timeCounter = 0;
	public float x;
	public float y;
	public float z;

	public float originalX;
	public float originalY;
	public float originalZ;
	

	// Use this for initialization
	void Start () 
	{
		originalX = transform.position.x;
		originalY = transform.position.y;
		originalZ = transform.position.z;
	}

	// Update is called once per frame
	void Update () 
	{
		timeCounter += speed*Time.deltaTime;
		x = originalX + Mathf.Cos (timeCounter) * 0.1f;
		y = originalY + Mathf.Sin (timeCounter) * 0.1f;
		z = originalZ;

		transform.position = new Vector3 (x, y, z);
	}
}
