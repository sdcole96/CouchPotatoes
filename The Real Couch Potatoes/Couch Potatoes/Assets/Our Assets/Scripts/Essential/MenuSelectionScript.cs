using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectionScript : MonoBehaviour {

    public GameObject bn;

	// Use this for initialization
	void Start () {
        bn.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
