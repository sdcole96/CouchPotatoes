using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalSpawner : MonoBehaviour 
{
	public List<GameObject> unusedSpawners = new List<GameObject> ();
	public List<GameObject> usedSpawners = new List<GameObject> ();
	public List<GameObject> targets = new List<GameObject> ();
	public GameObject selectedSpawner;
	public GameObject selectedTarget;
	public bool canSpawn = true; 


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canSpawn) 
		{
			selectedSpawner = unusedSpawners [Random.Range (0, unusedSpawners.Count)];
			selectedTarget = targets [Random.Range (0, targets.Count)];
			Instantiate (selectedTarget, selectedSpawner.transform.position, transform.rotation);

			canSpawn = false;

			unusedSpawners.Remove (selectedSpawner);
			usedSpawners.Add (selectedSpawner);

			if (unusedSpawners.Count == 0) 
			{
				unusedSpawners = new List<GameObject> (usedSpawners);

				usedSpawners.Clear();
			}

			StartCoroutine (Spawn ());
		}
	}

	public IEnumerator Spawn()
	{
		yield return new WaitForSeconds (3f);
		canSpawn = true;
	}
}
