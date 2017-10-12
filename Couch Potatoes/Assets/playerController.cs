using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float speed = 3.0f;
	public int jumpForce = 300;
	public float gravity;
	public Rigidbody rb;
	public bool isGrounded = true;

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

		if(Input.GetKeyDown(KeyCode.Joystick1Button16)||Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Space))
		{ 
			if (isGrounded)
			{
				jump ();
			}
		} 
	}

	public void jump()
	{
		rb.AddForce (new Vector3 (0, jumpForce, 0));
	}

	//Detects floor collision
	public void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Floor")
		{
			isGrounded = true;
		}
	}

	public void OnCollisionStay(Collision c)
	{
		isGrounded = true;
	}

	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit(Collision c){
		if(c.gameObject.tag == "Floor")
		{
			isGrounded = false;
		}
	}
}
