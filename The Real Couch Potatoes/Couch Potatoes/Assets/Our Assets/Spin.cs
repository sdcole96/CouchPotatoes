using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour 
{
	public float speed;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (spin ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spin()
	{
		yield return new WaitForSeconds (.1f);
		rb.AddTorque (Vector3.up * speed);
	}
}
