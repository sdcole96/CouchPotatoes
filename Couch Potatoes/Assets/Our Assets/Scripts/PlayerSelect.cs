using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public int playerNum = -1;
    public XboxController gamepad = new XboxController();

    // Use this for initialization
    void Start ()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            gamepad.isMac = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gamepad.getStartButton(ButtonQuery.Down) && GameMaster.activePlayers.Count < 4)
        {

            playerNum = GameMaster.activePlayers.Count;
        }
	}
}
