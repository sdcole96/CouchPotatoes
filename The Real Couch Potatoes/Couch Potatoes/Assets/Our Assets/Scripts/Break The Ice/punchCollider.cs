using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchCollider : MonoBehaviour {
	private GameObject left;
	private GameObject right;
	private Animator leftAnim;
	private Animator rightAnim;
	public float force = 500;
	private bool isPunching;

	// Use this for initialization
	void Start () {
		force = 500;
		isPunching = false;
		leftAnim = this.transform.GetChild (3).GetComponent<Animator> ();
		rightAnim = this.transform.GetChild (4).GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider col) 
	{
		
			if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Penguin") && col.gameObject.name != this.transform.root.name) {
				if (leftAnim.GetCurrentAnimatorStateInfo (0).IsName ("LeftPunch") || rightAnim.GetCurrentAnimatorStateInfo (0).IsName ("RightPunch")) {
					if (isPunching != true) {
						
						Vector3 dir = col.gameObject.transform.position - transform.parent.position;
						dir = -dir.normalized;
						Vector3 punchForce = new Vector3 (-dir.x * force, 5f, -dir.z * force);
						Debug.Log (punchForce);

						col.gameObject.GetComponent<Rigidbody> ().AddForce (punchForce);
						isPunching = true;
						StartCoroutine (coolDown ());
					}
				}
			}
	
	}

	void OnTriggerStay(Collider col)
	{
			if (col.gameObject.tag == "Player" && col.gameObject.name != this.transform.root.name) {
				if (leftAnim.GetCurrentAnimatorStateInfo (0).IsName ("LeftPunch") || rightAnim.GetCurrentAnimatorStateInfo (0).IsName ("RightPunch")) {
					if (isPunching != true) {
						Vector3 dir = col.gameObject.transform.position - transform.parent.position;
						dir = -dir.normalized;
						Vector3 punchForce = new Vector3 (-dir.x * force, 5f, -dir.z * force);
						Debug.Log (punchForce);

						col.gameObject.GetComponent<playerController> ().stunned = true;
						col.gameObject.GetComponent<Rigidbody> ().AddForce (punchForce);
						isPunching = true;
						StartCoroutine (coolDown ());
					}
				}
			}
	}
		

	public IEnumerator coolDown()
	{
		yield return new WaitForSeconds (1);
		isPunching = false;
	}


}
