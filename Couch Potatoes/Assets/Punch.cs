using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
	public float force;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
			if (col.gameObject.tag == "Player"  && col.gameObject.name != this.transform.root.name)
			{
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("LeftPunch")||anim.GetCurrentAnimatorStateInfo(0).IsName("RightPunch")) 
			{
				anim.Play ("New State");//stops punch so that multiple collisions dont occur
				Debug.Log ("FALCO PUNCH");
				Vector3 dir = col.contacts[0].point - transform.position;
				dir = -dir.normalized;
				col.gameObject.GetComponent<Rigidbody>().AddForce(-dir*force);
			}
		}
	}
		


}
