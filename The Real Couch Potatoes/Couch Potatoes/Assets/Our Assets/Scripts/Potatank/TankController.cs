using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	private float rightStick;
	private float leftStick;
	public bool stunned = false;
	public bool canFire = true;
	public bool dead = false;
	public int life = 3;
    public GameObject bullet;
    public GameObject firingPoint;
	public GameObject explosion;
	public PlayerIndex pi;
	public PotatanksGM gm;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rightStick = GamePad.GetAxis (CAxis.RX, pi);
		leftStick = GamePad.GetAxis(CAxis.LY, pi);
		if (!stunned) 
		{
			//this.transform.Translate ((-Vector3.forward * rightStick - Vector3.forward * leftStick)*.3f);
			//this.transform.Rotate (Vector3.up, 2 * rightStick - 2 * leftStick);
			this.transform.Translate((-Vector3.forward*leftStick)*.3f);
			this.transform.Rotate(new Vector3(0f,5f*rightStick,0f));
		}
			
		if (canFire && (GamePad.GetButton(CButton.RB, pi) || GamePad.GetButton(PSButton.R1, pi)))
        {
			StartCoroutine (FireRate(0.5f));
            Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        }

		if (life <= 0 && !dead) 
		{
			stunned = true;
			canFire = false;
			dead = true;
			StartCoroutine (TankDeath ());
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

	public IEnumerator FireRate(float seconds)
	{
		canFire = false;
		yield return new WaitForSeconds (seconds);
		canFire = true;
	}

	public IEnumerator TankDeath()
	{
		gm.playersLeft -= 1;
		GameObject exp = Instantiate (explosion, this.gameObject.transform);
		exp.transform.parent = null;
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}
}
