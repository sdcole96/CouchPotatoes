using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxisRaw("Horizontal") ;
		var z = Input.GetAxisRaw("Vertical") ;
		float heading = Mathf.Atan2(x,z);
		Debug.Log ("DEGREE: "+heading * Mathf.Rad2Deg);
		transform.rotation = Quaternion.Euler (0f, heading * Mathf.Rad2Deg, 0f);
		transform.Rotate(0, 0, 0);
	}
}
