using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
	// speed and angle
	public float rotationSpeed = 1.0f;
	public float rotationAngle = -90.0f;
	public bool hit = false;

	public GameObject pole;
	public GameObject target;
	public float originalY = 180f;
	public float originalZ = 0f;


	// Use this for initialization
	void Start () 
	{
		//originalY = target.transform.rotation.y;
		//originalZ = target.transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		pole.transform.Translate (Vector3.left * Time.deltaTime);
		
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			hit = true;
		}

		if (hit) 
		{
			
			Quaternion targetRotation = Quaternion.Euler (rotationAngle, originalY, originalZ);
			target.transform.rotation = Quaternion.Slerp (target.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);	
		}
	}
}
