using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			switch (this.gameObject.name)
			{
			case "Fries(Clone)":
				{
					col.gameObject.GetComponent<playerController> ().deepFryInventory [0] = true;
					Destroy (this.gameObject);
					break;
				}
			case "MashedPotatoes(Clone)":
				{
					col.gameObject.GetComponent<playerController> ().deepFryInventory [1] = true;
					Destroy (this.gameObject);
					break;
				}
			case "BakedPotato(Clone)":
				{
					col.gameObject.GetComponent<playerController> ().deepFryInventory [2] = true;
					Destroy (this.gameObject);
					break;
				}
			}
		}
	}
}
