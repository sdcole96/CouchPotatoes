using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public int playerNum = -1;
	public Rigidbody[] potatoes;
	int index = 0;
    //public XboxController gamepad = new XboxController();

    // Use this for initialization
    void Start ()
    {
//        if (Application.platform == RuntimePlatform.OSXPlayer)
//        {
//            gamepad.isMac = true;
//        }
		GamePadState state1 = GamePad.GetState(PlayerIndex.One);
		GamePadState state2 = GamePad.GetState(PlayerIndex.Two);
		GamePadState state3 = GamePad.GetState(PlayerIndex.Three);
		GamePadState state4 = GamePad.GetState(PlayerIndex.Four);
		GamePadState state5 = GamePad.GetState(PlayerIndex.Five);
		GamePadState state6 = GamePad.GetState(PlayerIndex.Six);
		GamePadState state7 = GamePad.GetState(PlayerIndex.Seven);
		GamePadState state8 = GamePad.GetState(PlayerIndex.Eight);
    }
	
	// Update is called once per frame
	void Update ()
    {
//        if (gamepad.getStartButton(ButtonQuery.Down) && GameMaster.activePlayers.Count < 4)
//        {
//
//            playerNum = GameMaster.activePlayers.Count;
//        }

		if((GamePad.GetButton(CButton.A, PlayerIndex.One) || GamePad.GetButton(PSButton.Cross, PlayerIndex.One)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 1);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 1");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Two) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Two)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 2);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 2");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Three) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Three)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 3);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 3");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Four) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Four)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 4);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 4");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Five) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Five)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 5);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 5");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Six) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Six)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 6);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 6");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Seven) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Seven)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 7);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 7");
		}
		else if((GamePad.GetButton(CButton.A, PlayerIndex.Eight) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Eight)) && GameMaster.activePlayers.Count < 4)
		{
			DropTater ();
			PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, 8);
			GameMaster.activePlayers.Add (newPlayer);
			Debug.Log ("Controller 8");
		}
	}

	public void DropTater()
	{
		//potatoes [GameMaster.activePlayers.Count].useGravity = true;
		potatoes[index].useGravity = true;
		index++;
	}
}
