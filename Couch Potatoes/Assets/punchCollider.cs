using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchCollider : MonoBehaviour {
	public GameObject left;
	public GameObject right;
	private Animator leftAnim;
	private Animator rightAnim;
	private float force = 30;

	// Use this for initialization
	void Start () {
		leftAnim = this.transform.GetChild (3).GetComponent<Animator> ();
		rightAnim = this.transform.GetChild (4).GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.tag == "Player"  && col.gameObject.name != this.transform.root.name)
		{
			if(leftAnim.GetCurrentAnimatorStateInfo(0).IsName("LeftPunch")||rightAnim.GetCurrentAnimatorStateInfo(0).IsName("RightPunch")) 
			{
				Vector3 dir = col.gameObject.transform.position - transform.parent.position;
				dir = -dir.normalized;
				Vector3 punchForce = new Vector3(-dir.x*force, 5f, -dir.z*force);
				Debug.Log(punchForce);

				col.gameObject.GetComponent<Rigidbody>().AddForce(punchForce);
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player"  && col.gameObject.name != this.transform.root.name)
		{
			if(leftAnim.GetCurrentAnimatorStateInfo(0).IsName("LeftPunch")||rightAnim.GetCurrentAnimatorStateInfo(0).IsName("RightPunch")) 
			{
				Vector3 dir = col.gameObject.transform.position - transform.parent.position;
				dir = -dir.normalized;
				Vector3 punchForce = new Vector3(-dir.x*force, 5f, -dir.z*force);
				Debug.Log(punchForce);

				col.gameObject.GetComponent<Rigidbody>().AddForce(punchForce);
			}
		}
	}


}
