using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVfade : MonoBehaviour {

	public GameObject pointB;
	public GameObject pointC;
	public GameObject floor;
	public bool work = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (work == true)
		{
			this.gameObject.transform.parent = null;
			GameObject.Find ("RotatingFloor").GetComponent<spin> ().enabled = false;
			StartCoroutine (moveCam ());
			work = false;
		}
	}

	IEnumerator moveCam()
	{
		float a = 0;
		Transform t = this.transform;
		while(a <= .35)
		{
			a += .01f;
			yield return new WaitForSeconds (.05f);
			this.transform.rotation = Quaternion.Slerp (transform.rotation, pointC.transform.rotation, a);
			this.transform.position = Vector3.Lerp (t.position, pointB.transform.position, a);
		}
		float b = 0;
		while(b <= .25125)
		{
			this.transform.position += new Vector3 (0, -.01f, .08f);
			b += .01f;
			yield return new WaitForSeconds (.05f);
		}
	}
}
