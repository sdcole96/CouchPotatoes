using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	private float rightStick;
	private float leftStick;
    public GameObject bullet;
    public GameObject firingPoint;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rightStick = GamePad.GetAxis (CAxis.RY);
		leftStick = GamePad.GetAxis(CAxis.LY);
		this.transform.Translate ((-Vector3.forward * rightStick - Vector3.forward * leftStick)*.3f);
		this.transform.Rotate (Vector3.up, 2 * rightStick - 2 * leftStick);

        if (GamePad.GetButton(CButton.RB) || GamePad.GetButton(PSButton.R1))
        {
            Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        }
    }
}
