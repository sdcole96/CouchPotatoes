using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {
	
	public Camera c;
	public GameObject cameraDestination;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (wait ());

		//c.transform.position = Vector3.MoveTowards (penguin.transform.position, cameraDestination.transform.position, 2.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1.5f);
		GameObject ice = GameObject.Find ("CutsceneIce");
		ice.GetComponent<Animator> ().Play ("fallingIce");
	}
}
