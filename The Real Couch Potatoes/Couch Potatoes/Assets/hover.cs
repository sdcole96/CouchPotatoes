using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour {

	public bool isFloating = true;
	public int multiplier = 1;
	public float range = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine(move());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator move()
	{
		while(isFloating)
		{
			yield return new WaitForSeconds(.001f);
			if(range > 1)
			{
				multiplier = -1;
			}
			else if(range < -1)
			{
				multiplier = 1;
			}
			this.transform.position += new Vector3(0f,.05f*multiplier,0f);
			range += .05f*multiplier;
		}
	}

}
