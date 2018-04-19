using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour {

	float i = -1;
	float multiplier = 1;
	// Use this for initialization
	void Start () {
		StartCoroutine(hover());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator hover()
	{
		yield return new WaitForSeconds(.1f);
		if(i == 1 || i == 0)
		{
			multiplier *= (-multiplier);
		}
		i += (multiplier * .1f);

		this.transform.position += new Vector3(0,0,i);
	}
	

}
