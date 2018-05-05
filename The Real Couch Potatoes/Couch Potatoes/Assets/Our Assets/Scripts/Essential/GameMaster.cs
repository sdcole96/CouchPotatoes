using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static PlayerClass player1;
    public static PlayerClass player2;
    public static PlayerClass player3;
    public static PlayerClass player4;
    public static List<PlayerClass> activePlayers = new List<PlayerClass>();

    public static int player1Score = 0;
    public static int player2Score = 0;
    public static int player3Score = 0;
    public static int player4Score = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static void AddScore(int playerNum, int points)
    {
		int newScore = activePlayers [playerNum].GetPScore () + points;
		activePlayers[playerNum].SetPScore(newScore);
    }

    public static void Reset()
    {
        activePlayers = new List<PlayerClass>();
    }
}
