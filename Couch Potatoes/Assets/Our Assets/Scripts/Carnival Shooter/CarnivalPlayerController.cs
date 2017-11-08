using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalPlayerController : MonoBehaviour 
{
	public float speed = 100.0f;
	public int playerNum = -1;
	public XboxController gamepad = new XboxController ();
	public CarnivalShootGM GM;

	// Use this for initialization
	void Start () 
	{
		GM = GameObject.Find ("Game Manager").GetComponent<CarnivalShootGM> ();
		gamepad.playerNum = playerNum;
		if (Application.platform == RuntimePlatform.OSXPlayer) 
		{
			gamepad.isMac = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		var xIn = gamepad.getAxisX(ButtonQuery.Hold);
		var yIn = -gamepad.getAxisY (ButtonQuery.Hold);

		var x =  xIn * Time.deltaTime * speed;
		var y = yIn * Time.deltaTime * speed;

		if (Mathf.Abs (xIn) > .075f || Mathf.Abs (yIn) > .075f) 
		{
			transform.Translate(x, y, 0);
		}

		if(gamepad.getAButton(ButtonQuery.Down)||Input.GetKeyDown(KeyCode.Space))
		{ 
			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit)) 
			{
				if (hit.collider.tag.Equals("Target")) 
				{
					Target targetHit = hit.transform.gameObject.transform.root.GetComponent<Target> ();
					targetHit.hit = true;
					GM.UpdatePlayerScore (playerNum, targetHit.pointValue);
					hit.collider.enabled = false;
				}
			}
		} 
	}
}
