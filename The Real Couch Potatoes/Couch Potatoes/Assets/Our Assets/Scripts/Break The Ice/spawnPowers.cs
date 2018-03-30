using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowers : MonoBehaviour {
	
	public GameObject powerUp;
	public GameObject strengthPowerUp;
	public GameObject penguin;
	public Material red;
	public Material blue;



	// Use this for initialization
	void Start () 
	{
		StartCoroutine (spawnWait ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnWait()
	{
		yield return new WaitForSeconds (8);
		for (int j = 0; j < 10; j++) {
			int i = Random.Range (5, 15);
			yield return new WaitForSeconds (i);
			GameObject[] g = GameObject.FindGameObjectsWithTag ("Floor");
			GameObject ice = g [Random.Range (0, g.Length)];


			switch (Random.Range (0, 2)) {
			case 0:
				{
					GameObject power = Instantiate (powerUp, new Vector3 (ice.transform.position.x, 20, ice.transform.position.z), new Quaternion ());	

					power.AddComponent<Rigidbody> ();
					power.AddComponent<BoxCollider> ();
					power.tag = "Powerup";
					power.name = "Speed";
					power.GetComponent<Rigidbody> ().mass = .000001f;
					break;
				}
			case 1:
				{
					GameObject power = Instantiate (strengthPowerUp, new Vector3 (ice.transform.position.x, 20, ice.transform.position.z), new Quaternion ());	

					power.AddComponent<Rigidbody> ();
					power.AddComponent<BoxCollider> ();
					power.tag = "Powerup";
					power.name = "Strength";

					power.GetComponent<Rigidbody> ().mass = .000001f;
					break;
				}
			default:
				{
					break;
				}
			}
		}
	}
}
