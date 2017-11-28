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
    public GameObject lastTargetUsed = null;
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
            while (selectedSpawner == lastTargetUsed)
            {
                selectedSpawner = unusedSpawners[Random.Range(0, unusedSpawners.Count)];
            }

			if (selectedSpawner.name == "Spawner 2" || selectedSpawner.name == "Spawner 4") 
			{
				selectedTarget = targets [Random.Range (0, (targets.Count/2))+9];
				Instantiate (selectedTarget, selectedSpawner.transform.position, transform.rotation);
			} 
			else 
			{
				selectedTarget = targets [Random.Range (0, (targets.Count/2))];
				Instantiate (selectedTarget, selectedSpawner.transform.position, transform.rotation);
			}

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
		yield return new WaitForSeconds (1f);
		canSpawn = true;
	}
}
