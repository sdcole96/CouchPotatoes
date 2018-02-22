using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drift : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (drifting ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator drifting()
	{
		yield return new WaitForSeconds (.05f);
		transform.position = new Vector3 (this.transform.position.x + 1f, this.transform.position.y, this.transform.position.y);

	}
}
