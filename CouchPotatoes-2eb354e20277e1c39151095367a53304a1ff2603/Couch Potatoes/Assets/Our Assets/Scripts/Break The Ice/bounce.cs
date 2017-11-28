using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player") 
		{
			Debug.Log ("BOUNCE");
			c.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 500, 0));
		}
	}
}
