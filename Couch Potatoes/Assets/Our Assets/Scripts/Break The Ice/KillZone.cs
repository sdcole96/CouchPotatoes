using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			GameObject[] g = GameObject.FindGameObjectsWithTag ("Player");
			int playerNumber = c.gameObject.GetComponent<playerController> ().playerNum;
			int score = 4 - g.Length;
			foreach(GameObject o in g)
			{
				if (o.name != this.name) 
				{
					//GameMaster.addScore (o.gameObject.GetComponent<playerController> ().playerNum, 3);
				}
			}
			//GameMaster.addScore(c.gameObject.GetComponent<playerController>().playerNum,score);
			Destroy (c.gameObject);
		}
	}


}
