using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

	public float trig = 0;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (count ());
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator changeColor()
	{
		foreach (Transform child in transform)
		{
				for(float i = 0; i < 100; i+=0.01f)
				{
					yield return new WaitForSeconds(.01f);
					Color c = new Color (i, .5f, .5f);
					transform.GetComponent<Text> ().color = c;
					//do something with the color
				}
		}
	}

	IEnumerator count()
	{
		int i = 3;
		yield return new WaitForSeconds (5f);
		while(i != 0)
		{
            
			foreach (Transform child in transform)
			{
                if (child.name != "whitescreen")
                {
                    child.GetComponent<Text>().text = "     " + (i).ToString();
                }
			}
			yield return new WaitForSeconds (1f);
			i--;
            

		}
		GameObject.Find ("Song").GetComponent<AudioSource> ().enabled = true;
		foreach (playerController p in GameObject.FindObjectsOfType<playerController> ()) 
		{
			p.enabled = true;
		}
        
		foreach (Transform child in transform)
		{
            if (child.name != "whitescreen")
            {
                child.GetComponent<Text>().text = "     Go!";
            }
            
		}

		yield return new WaitForSeconds(.5f);
		foreach (Transform child in transform)
		{
            if (child.name != "whitescreen")
            {
                child.GetComponent<Text>().text = " ";
            }
		}

	}

}
