using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headBounce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log("AHHHHH");
		//if (c.gameObject.tag == "Player") 
		//{
			//c.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 10, 0));
		//}
	}
}
