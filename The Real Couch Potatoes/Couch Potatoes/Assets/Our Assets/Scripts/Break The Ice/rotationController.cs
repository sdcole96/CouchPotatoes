using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour {

    public PlayerIndex controllerNum;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
        Vector2 movement = GamePad.GetLeftStick(controllerNum);

		float degree = Mathf.Atan2(movement.x, -movement.y)* Mathf.Rad2Deg;
		if (!(movement.x==0 && movement.y ==0)) 
		{
			transform.rotation = Quaternion.Euler (0f, degree, 0f);
		}
	}
}
