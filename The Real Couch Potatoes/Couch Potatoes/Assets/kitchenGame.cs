using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenGame : MonoBehaviour {

	public GameObject[] players;
	public bool gameOver;
	public Vector3 winLocation;
	public Camera cam;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (GameObject p in players)
		{
			if(p.GetComponent<playerController> ().deepFry ())
			{
				gameOver = true;
				winLocation = p.gameObject.transform.position;
			}
			if(gameOver)
			{
				StartCoroutine (end());
				p.GetComponent<playerController>().enabled = false;

			}
		}
			
	}

	IEnumerator end()
	{
		yield return new WaitForSeconds (1f);
		cam.GetComponent<fadeInFadeOut> ().FadeOut ();
		yield return new WaitForSeconds (1f);
		cam.GetComponent<ChangeScene> ().LoadSceneMM ();
	}


}
