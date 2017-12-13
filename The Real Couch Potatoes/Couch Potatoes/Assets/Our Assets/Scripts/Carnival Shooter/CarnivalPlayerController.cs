using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalPlayerController : MonoBehaviour 
{
	public float speed = 100.0f;
	public int playerNum = -1;
	public bool canHit = true;
	public PlayerIndex controllerNum;
	public CarnivalShootGM GM;

	// Use this for initialization
	void Start () 
	{
		GM = GameObject.Find ("Game Manager").GetComponent<CarnivalShootGM> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		var xIn = GamePad.GetAxis (CAxis.LX, controllerNum);
		var yIn = -GamePad.GetAxis (CAxis.RX, controllerNum);

		var x =  xIn * Time.deltaTime * speed;
		var y = yIn * Time.deltaTime * speed;

		Vector2 movement = GamePad.GetLeftStick (controllerNum);
		transform.Translate(movement.x * 0.40f, -(movement.y * 0.40f), 0);

		if((GamePad.GetButton(CButton.A, controllerNum) || GamePad.GetButton(PSButton.Cross, controllerNum))&&canHit)
		{
			StartCoroutine(FireRate(1.0f));
			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit)) 
			{
                if (hit.collider.tag.Equals("Target"))
                {
                    Target targetHit = hit.transform.gameObject.transform.root.GetComponent<Target>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(playerNum);
                }
                else if (hit.collider.tag.Equals("SeagullTarget"))
                {
                    SeagullTarget targetHit = hit.transform.gameObject.transform.root.GetComponent<SeagullTarget>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(hit.transform.gameObject.GetComponent<MeshRenderer>(), playerNum);
                }
                else if (hit.collider.tag.Equals("DolphinTarget"))
                {
                    DolphinTarget targetHit = hit.transform.gameObject.transform.root.GetComponent<DolphinTarget>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(hit.transform.gameObject.GetComponent<MeshRenderer>(), playerNum);
                }
			}
		} 
	}
	
	public IEnumerator FireRate(float seconds)
	{
		canHit = false;
		yield return new WaitForSeconds(seconds);
		canHit = true;
	}
}
