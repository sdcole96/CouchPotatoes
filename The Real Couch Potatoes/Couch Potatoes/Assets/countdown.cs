using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (count ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator count()
	{
		int i = 4;
		yield return new WaitForSeconds (5f);
		while(i != 0)
		{
			yield return new WaitForSeconds (1f);
			i--;

				foreach (Transform child in transform)
				{
					child.GetComponent<Text> ().text = (i).ToString ();
				}
		}
		foreach (playerController p in GameObject.FindObjectsOfType<playerController> ()) 
		{
			p.enabled = true;
		}
		foreach (Transform child in transform)
		{
			child.GetComponent<Text> ().text = "Go!";
		}
		yield return new WaitForSeconds(.5f);
		foreach (Transform child in transform)
		{
			Destroy(child);
		}

	}

}
