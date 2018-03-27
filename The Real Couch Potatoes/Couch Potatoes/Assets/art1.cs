using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class art1 : MonoBehaviour {

	public float speed;
	public int i = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (lookgood (speed));	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator lookgood(float s)
	{
		i++;
		yield return new WaitForSeconds (s);
		this.transform.Rotate (new Vector3 (0, i, i));
	}
}
