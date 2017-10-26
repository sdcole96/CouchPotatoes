using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingIce : MonoBehaviour {

	public int seconds = 5;
	public int i = 0;
	public GameObject[] players;

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
		while (childCount > 2) 
		{
			childCount = transform.childCount;

			yield return new WaitForSeconds (waitTime);

			players = GameObject.FindGameObjectsWithTag("Player");
			int rand = Random.Range (0, players.Length);
			GameObject g = findClosestIce (players[rand]);

			//Transform ice = transform.GetChild(rand).GetChild(0);
			Animator iceAnim = g.GetComponent<Animator> ();
			iceAnim.Play ("fallingIce");
		}
	}

	public GameObject findClosestIce(GameObject g)
	{
		GameObject[] ice;
		ice = GameObject.FindGameObjectsWithTag ("Floor");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = g.transform.position;
		foreach (GameObject i in ice)
		{
			Vector3 diff = i.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = i;
				distance = curDistance;
			}
		}
		return closest;
	}
}
