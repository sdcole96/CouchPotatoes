using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	private float rightStick;
	private float leftStick;
	public bool stunned = false;
	public int life = 3;
    public GameObject bullet;
    public GameObject firingPoint;
	public int playerNum;
	public PlayerIndex pi;

	// Use this for initialization
	void Start () 
	{
		if (playerNum == 1)
			pi = PlayerIndex.One;
		else if(playerNum == 2)
			pi = PlayerIndex.Two;
	}
	
	// Update is called once per frame
	void Update () 
	{
		rightStick = GamePad.GetAxis (CAxis.RY, pi);
		leftStick = GamePad.GetAxis(CAxis.LY, pi);
		if (!stunned) 
		{
			this.transform.Translate ((-Vector3.forward * rightStick - Vector3.forward * leftStick)*.3f);
			this.transform.Rotate (Vector3.up, 2 * rightStick - 2 * leftStick);
		}
			
        if (GamePad.GetButton(CButton.RB, pi) || GamePad.GetButton(PSButton.R1, pi))
        {
            Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        }
    }

	public void Hit()
	{
		StartCoroutine (Stun ());
	}

	public IEnumerator Stun()
	{
		stunned = true;
		yield return new WaitForSeconds (0.5f);
		stunned = false;
	}
}
