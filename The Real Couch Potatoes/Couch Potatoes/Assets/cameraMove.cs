using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (move ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator move()
	{
		yield return new WaitForSeconds (5f);
		float t = 0;

		for(t = 0f; t<=1f; t += .01f)
		{
			yield return new WaitForSeconds (.01f);
			this.transform.position = Vector3.Lerp (this.transform.position, GameObject.Find ("CameraLoc").transform.position,t);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, GameObject.Find ("CameraLoc").transform.rotation, t);
		}
	}
}
