using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour {

	public int playerNum = -1;
	public XboxController gamepad = new XboxController ();

	// Use this for initialization
	void Start () 
	{
		gamepad.playerNum = playerNum;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = gamepad.getAxisX(ButtonQuery.Hold);
		var z = -gamepad.getAxisY (ButtonQuery.Hold);

		float degree = Mathf.Atan2(x,z)* Mathf.Rad2Deg;
		if (!(x==0 && z ==0)) 
		{
			transform.rotation = Quaternion.Euler (0f, degree, 0f);
		}
	}
}
