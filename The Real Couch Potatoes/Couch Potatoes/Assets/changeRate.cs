using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRate : MonoBehaviour {

	public Material m;
	public float i = 0f;
	public int multiplier = 1;
	public bool active = true;
	// Use this for initialization
	void Start () {
		StartCoroutine(change());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator change()
	{
		while(active)
		{
			if(i > 20)
			{
				multiplier = -1;
			}
			else if (i <= .6)
			{
				multiplier = 1;
			}
			yield return new WaitForSeconds(.01f);
			//i += multiplier * .1f;
			m.SetFloat("_Spread",i);
		}
	}
}
