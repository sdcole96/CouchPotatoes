using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour {

	public GameObject[] asteroids;
	public GameObject[] spawnPoints;
	public bool canSpawn = true;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Spawn ());
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public IEnumerator Spawn()
	{
		if (canSpawn) 
		{
			int rand = Random.Range (0, asteroids.Length);
			Instantiate (asteroids [rand], new Vector3 (spawnPoints [0].transform.position.x, spawnPoints [0].transform.position.y, Random.Range (spawnPoints [0].transform.position.z, spawnPoints [1].transform.position.z)), spawnPoints [0].transform.rotation);
			yield return new WaitForSeconds(Random.Range(.5f, 2f));
			StartCoroutine (Spawn ());
		}
	}
}
