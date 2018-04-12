using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnFood : MonoBehaviour {

	public GameObject[] food;
	public GameObject[] spawns;

	public bool keepCooking = true;
	public int i = 0;

	// Use this for initialization
	void Start () {

		StartCoroutine(startupCooking ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator startupCooking()
	{
		yield return new WaitForSeconds (1.5f);
		GameObject g = Instantiate (food[0], this.transform.position,new Quaternion());
		g.AddComponent<Rigidbody> ();
		g.GetComponent<Rigidbody> ().AddForce (Vector3.up * 600);
		GameObject g1 = Instantiate (food[1], this.transform.position,new Quaternion());
		g1.AddComponent<Rigidbody> ();
		g1.GetComponent<Rigidbody> ().AddForce (Vector3.up * 600);
		GameObject g2 = Instantiate (food[2], this.transform.position,new Quaternion());
		g2.AddComponent<Rigidbody> ();
		g2.GetComponent<Rigidbody> ().AddForce (Vector3.up * 600);


		g.GetComponent<BoxCollider> ().enabled = true;
		g.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		g1.GetComponent<BoxCollider> ().enabled = true;
		g1.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		g2.GetComponent<BoxCollider> ().enabled = true;
		g2.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

		yield return new WaitForSeconds (.14f);
		g.GetComponent<Rigidbody> ().AddForce (spawns [1].gameObject.transform.position*10);
		g1.GetComponent<Rigidbody> ().AddForce (spawns [2].gameObject.transform.position*10);
		g2.GetComponent<Rigidbody> ().AddForce (spawns [3].gameObject.transform.position*50);

		StartCoroutine (cook ());
	}

	IEnumerator cook()
	{
		int j = 0;
		while (keepCooking) 
		{
			yield return new WaitForSeconds (10f);
			if (i == 3) 
			{
				i = 0;
			}

			GameObject g = Instantiate (food[i], this.transform.position,new Quaternion());
			g.GetComponent<Rigidbody> ().AddForce (Vector3.up * 600);
			int r = Random.Range (0, spawns.Length);
			while (r == j) //make sure that this spawn is not the last one that was spawned at
			{
				 r = Random.Range (0, 10);
			}
			Vector3 v = new Vector3 (spawns [r].transform.position.x * Random.Range (10, 15), 0, spawns [r].transform.position.z * Random.Range (10, 15));
			Debug.Log (v);
		
			g.GetComponent<Rigidbody> ().AddForce (v);
			g.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		

			i++;
			 j = r;
		}
	
	}
}
