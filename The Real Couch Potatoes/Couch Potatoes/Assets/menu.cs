using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	public int i = 1;

	public GameObject one;
	public GameObject two;
	public GameObject three;

	public Material m1;
	public Material m2;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			i--;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			i++;
		}
		switch (i)
		{
			case 1:
			{
				one.GetComponent<MeshRenderer>().material = m1;
				two.GetComponent<MeshRenderer>().material = m2;
				three.GetComponent<MeshRenderer>().material = m2;
				
				break;
			}
			case 2:
			{
				one.GetComponent<MeshRenderer>().material = m2;
				two.GetComponent<MeshRenderer>().material = m1;
				three.GetComponent<MeshRenderer>().material = m2;
				break;
			}
			case 3:
			{
				one.GetComponent<MeshRenderer>().material = m2;
				two.GetComponent<MeshRenderer>().material = m2;
				three.GetComponent<MeshRenderer>().material = m1;
				break;
			}
		}
	}


}
