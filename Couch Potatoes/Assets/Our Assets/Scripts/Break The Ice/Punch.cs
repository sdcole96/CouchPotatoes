using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    public float force;
	private Animator anim;
	// Use this for initialization
	void Start () {
        force = 400;
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		/*
			if (col.gameObject.tag == "Player"  && col.gameObject.name != this.transform.root.name)
			{
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("LeftPunch")||anim.GetCurrentAnimatorStateInfo(0).IsName("RightPunch")) 
			{
				anim.Play ("New State");//stops punch so that multiple collisions dont occur
				Debug.Log ("COLLISION ENTER");
				Vector3 dir = col.gameObject.transform.position - transform.parent.parent.position;
				dir = -dir.normalized;
                Vector3 punchForce = new Vector3(-dir.x*force, 5f, -dir.z*force);
                Debug.Log(punchForce);

                col.gameObject.GetComponent<Rigidbody>().AddForce(punchForce);

			}
		}
		*/
	}

    
	//void OnTriggerStay(Collider col)
	//{
	//	if (col.gameObject.tag == "Player"  && col.gameObject.name != this.transform.root.name)
	//	{
	//		if(anim.GetCurrentAnimatorStateInfo(0).IsName("LeftPunch")||anim.GetCurrentAnimatorStateInfo(0).IsName("RightPunch")) 
	//		{
	//			anim.Play ("New State");//stops punch so that multiple collisions dont occur
	//			Debug.Log ("TRIGGER STAY");
	//			col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(force,0f,force));
	//		}
	//	}
	//}
		


}
