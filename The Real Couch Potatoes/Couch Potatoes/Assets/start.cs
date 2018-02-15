using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
		
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Bot ()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log ("HEY");
		this.transform.position = new Vector3 (this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
	}



}
