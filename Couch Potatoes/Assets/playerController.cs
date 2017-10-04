using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float speed = 3.0f;
	public int jumpForce = 300;
	public float gravity;
	public Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3(0, gravity, 0);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);

		if(Input.GetKeyDown(KeyCode.Space))
		{ 
			jump();
		} 
	}

	public void jump()
	{
		rb.AddForce (new Vector3 (0, jumpForce, 0));
	}
}
