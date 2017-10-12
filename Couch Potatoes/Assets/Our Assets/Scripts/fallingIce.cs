using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingIce : MonoBehaviour {

	public int seconds = 5;
	public int i = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (dropIce(seconds));
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void destroyMe()
	{
		
	}

	private IEnumerator dropIce(float waitTime)
	{
		int childCount = transform.childCount;
		while (childCount > 1) 
		{
			yield return new WaitForSeconds (waitTime);

			//childCount = transform.childCount;
			int rand = Random.Range (0, transform.childCount);
			Transform ice = transform.GetChild(rand).GetChild(0);
			Animator iceAnim = ice.GetComponent<Animator> ();
			iceAnim.Play ("FallingIce");
		}
	}
}
