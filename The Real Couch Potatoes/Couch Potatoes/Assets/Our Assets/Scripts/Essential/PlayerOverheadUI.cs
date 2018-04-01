using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOverheadUI : MonoBehaviour {


    playerController pc;
    Text textComponent;
    

	// Use this for initialization
	void Start () {
        pc = this.gameObject.GetComponent<playerController>();
        textComponent = this.gameObject.GetComponentInChildren<Text>();
        textComponent.text = "P" + pc.playerNum.ToString();
        textComponent.color = GameMaster.activePlayers[pc.playerNum - 1].GetPColor();
	}
	
	// Update is called once per frame
	void Update () {
        // Hide UI text when game begins
        if (textComponent.enabled && pc.enabled)
            textComponent.enabled = false;
	}
}
