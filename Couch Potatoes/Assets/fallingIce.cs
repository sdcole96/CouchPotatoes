using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingIce : MonoBehaviour {

	public int seconds = 3;
	public int i = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (dropIce(5));
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	private IEnumerator dropIce(float waitTime)
	{
		while (transform.childCount != 1) 
		{
			yield return new WaitForSeconds (waitTime);
			transform.GetChild(i).GetComponent<Animator> ().Play ("FallingFloor");
			i++;
		}
	}
}
