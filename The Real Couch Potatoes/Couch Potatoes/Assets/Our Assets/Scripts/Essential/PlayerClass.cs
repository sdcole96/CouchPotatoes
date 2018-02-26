using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    private int playerNum;
    private PlayerIndex controllerNum;
	private int playerScore;
	private Color playerColor;

	public PlayerClass(int nPlayerNum, PlayerIndex nControllerNum)
	{
		playerNum = nPlayerNum;
		controllerNum = nControllerNum;
		playerScore = 0;
	}

	public int GetPNum()
	{
		return playerNum;
	}
	public PlayerIndex GetPIndex()
	{
		return controllerNum;
	}
	public int GetPScore()
	{
		return playerScore;
	}
	public Color GetPColor()
	{
		return playerColor;
	}

	public void SetPNum(int pNum)
	{
		playerNum = pNum;
	}
	public void SetPIndex(PlayerIndex cNum)
	{
		controllerNum = cNum;
	}
	public void SetPScore(int pScore)
	{
		playerScore = pScore;
	}
	public void SetPColor(Color pColor)
	{
		playerColor = pColor;
	}
}
