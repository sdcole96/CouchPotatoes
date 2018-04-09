using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayWinner : MonoBehaviour {

    public GameObject[] spriteBoxes;
    public GameObject[] winnerBoxes;
    public GameObject gameController;
    public RuntimeAnimatorController redAnim;
    public RuntimeAnimatorController greenAnim;
    public RuntimeAnimatorController blueAnim;
    public RuntimeAnimatorController yellowAnim;

    public Sprite redSprite;
    public Sprite greenSprite;
    public Sprite blueSprite;
    public Sprite yellowSprite;

    private fallingIce iceController;

    public bool isSetup;

    // Use this for initialization
    void Start () {
        isSetup = false;
        // Break the Ice
        iceController = gameController.GetComponent<fallingIce>();

    }
	
	// Update is called once per frame
	void Update () {
		if(iceController.gameOver && !isSetup)
        {
            isSetup = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true); // enable canvas

            // Set winner; (Make sure you also check for ties!, might mess with the player numcheck below on Break the Ice)
            int winningPlayerNum = iceController.players[0].GetComponent<playerController>().playerNum -1;
            Color winningColor = GameMaster.activePlayers[winningPlayerNum].GetPColor();

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
    }
}
