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
		float x = Input.GetAxisRaw("Horizontal") ;
		float z = Input.GetAxisRaw("Vertical") ;

		float degree = Mathf.Atan2(x,z)* Mathf.Rad2Deg;
		if (!(x==0 && z ==0)) 
		{
			transform.rotation = Quaternion.Euler (0f, degree, 0f);
		}
	}
}
