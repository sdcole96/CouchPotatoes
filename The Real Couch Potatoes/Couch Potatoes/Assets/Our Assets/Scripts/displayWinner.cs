using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayWinner : MonoBehaviour {

    public GameObject[] spriteBoxes;
    public GameObject[] winnerBoxes;
    public GameObject gameController;
    public int minigame; // 1 is Break the Ice, 2 is Shooting Gallery, 3 is Potatanks

    private bool gameIsOver;

    public RuntimeAnimatorController redAnim;
    public RuntimeAnimatorController greenAnim;
    public RuntimeAnimatorController blueAnim;
    public RuntimeAnimatorController yellowAnim;

    public Sprite redSprite;
    public Sprite greenSprite;
    public Sprite blueSprite;
    public Sprite yellowSprite;

    private fallingIce iceController;
    private CarnivalShootGM carnivalController;
    private PotatanksGM potatanksController;
    private kitchenGame kitchenController;

    public bool isSetup;

    int winPlayerNumGameOver; // Used for game over screen on main menu
    public GameObject mainCanvas;

    // Use this for initialization
    void Start () {
        isSetup = false;
        gameIsOver = false;
        if (minigame == 1) // Break the Ice
        {
            iceController = gameController.GetComponent<fallingIce>();
        }
        else if (minigame == 2) // Shooting Gallery
        {
            carnivalController = gameController.GetComponent<CarnivalShootGM>();
        }
        else if (minigame == 3) // Potatanks
        {
            potatanksController = gameController.GetComponent<PotatanksGM>();
        }
        else if (minigame == 5) // Deep Fry
        {
            kitchenController = gameController.GetComponent<kitchenGame>();
        }

        else if (minigame == 4) // Game Over 
        {
            for (int i = 0; i < GameMaster.activePlayers.Count; i++)
            {
                int winnerScore = GameMaster.activePlayers[i].GetPScore(); // This does not handle ties yet :-/
                if (winnerScore >= 3)
                {
                    winPlayerNumGameOver = i;
                    gameIsOver = true;
                    break;
                }

            }

        }




    }
	
	// Update is called once per frame
	void Update () {
        if (minigame == 1)
        {
            gameIsOver = iceController.gameOver;
        }
        else if (minigame == 2)
        {
            gameIsOver = carnivalController.gameOver;
        }
        else if (minigame == 3)
        {
            gameIsOver = potatanksController.gameOver;
        }
        else if (minigame == 5) // Deep Fry
        {
            gameIsOver = kitchenController.gameOver;
        }


		if(gameIsOver && !isSetup)
        {
            isSetup = true;

            if(minigame == 4) // disable mainCanvas
            {
                mainCanvas.SetActive(false);
                GameObject.FindGameObjectWithTag("ColorLight").GetComponent<Light>().color = new Color((float)0.22222222222, (float)0.10222222222, 1, 1);
                
            }
               

            gameObject.transform.GetChild(0).gameObject.SetActive(true); // enable canvas

            int winningPlayerNum = -1; // Temp/Trash value to avoid compiler errors
            Color winningColor = Color.white; // Temp/Trash value to avoid compiler errors

            // Set winner; (Make sure you also check for ties!, might mess with the player numcheck below on Break the Ice)
            if (minigame == 1)
            {
                winningPlayerNum = iceController.players[0].GetComponent<playerController>().playerNum -1;
                winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();
            }
            else if (minigame == 2)
            {
                winningPlayerNum = carnivalController.winnerIndex;
                winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();
            }
            else if (minigame == 3)
            {
				winningPlayerNum = potatanksController.winningIndex - 1;
				winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();
            }
            else if (minigame == 5) //  Deep Fry
            {
                winningPlayerNum = kitchenController.players[0].GetComponent<playerController>().playerNum - 1;
                winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();
            }
            else if (minigame == 4)
            {
                winningPlayerNum = winPlayerNumGameOver;
                winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();
            }

            for (int i = 0; i < GameMaster.activePlayers.Count; i++)
            {
                Color colorToCheck = GameMaster.activePlayers[i].GetPColor();

                if (colorToCheck == Color.red)
                    spriteBoxes[i].GetComponent<Image>().sprite = redSprite;
                if (colorToCheck == Color.green)
                    spriteBoxes[i].GetComponent<Image>().sprite = greenSprite;
                if (colorToCheck == Color.blue)
                    spriteBoxes[i].GetComponent<Image>().sprite = blueSprite;
                if (colorToCheck == Color.yellow)
                    spriteBoxes[i].GetComponent<Image>().sprite = yellowSprite;
                spriteBoxes[i].GetComponent<Image>().enabled = true; // Enable the Image'
            }

            StartCoroutine(WaitThenDisplayWinner(winningPlayerNum, winningColor));
        }
	}

    IEnumerator WaitThenDisplayWinner(int winnersNumber, Color winnersColor)
    {
        yield return new WaitForSeconds(3.0f);
        if (winnersColor == Color.red)
            spriteBoxes[winnersNumber].GetComponent<Animator>().runtimeAnimatorController = redAnim as RuntimeAnimatorController; // Pop in requested animation
        if (winnersColor == Color.green)
            spriteBoxes[winnersNumber].GetComponent<Animator>().runtimeAnimatorController = greenAnim as RuntimeAnimatorController; // Pop in requested animation
        if (winnersColor == Color.blue)
            spriteBoxes[winnersNumber].GetComponent<Animator>().runtimeAnimatorController = blueAnim as RuntimeAnimatorController; // Pop in requested animation
        if (winnersColor == Color.yellow)
            spriteBoxes[winnersNumber].GetComponent<Animator>().runtimeAnimatorController = yellowAnim as RuntimeAnimatorController; // Pop in requested animation
        winnerBoxes[winnersNumber].GetComponent<Text>().enabled = true; // Enable the winners tag over the winner
        // Here we increment the score
        GameMaster.activePlayers[winnersNumber].IncrementPScore();
    }
}
