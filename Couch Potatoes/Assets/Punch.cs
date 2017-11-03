using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
	public float force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.name != this.transform.root.name)
		{
			Debug.Log ("FALCO PUNCH");
			Vector3 dir = col.contacts[0].point - transform.position;
			dir = -dir.normalized;
			col.gameObject.GetComponent<Rigidbody>().AddForce(-dir*force);
		}
	}
		


}
