using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int playerNum;
    public int controllerNum;
	public int playerScore = 0;

	public PlayerClass(int nPlayerNum, int nControllerNum)
	{
		playerNum = nPlayerNum;
		controllerNum = nControllerNum;
		playerScore = 0;
	}
}
