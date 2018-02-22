using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	float rightStick;
	float leftStick;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rightStick = GamePad.GetAxis (CAxis.RY);
		leftStick = GamePad.GetAxis(CAxis.LY);
		this.transform.Translate (-Vector3.forward * rightStick - Vector3.forward * leftStick);
	}
}
