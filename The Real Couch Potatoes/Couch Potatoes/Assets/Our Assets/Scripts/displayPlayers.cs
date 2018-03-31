using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPlayers : MonoBehaviour {

    public GameObject[] spriteBoxes;
    public GameObject[] scoreBoxes;
    public RuntimeAnimatorController redAnim;
    public RuntimeAnimatorController greenAnim;
    public RuntimeAnimatorController blueAnim;
    public RuntimeAnimatorController yellowAnim;



    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < GameMaster.activePlayers.Count; i++)
        {
            Color colorToCheck = GameMaster.activePlayers[i].GetPColor();
            spriteBoxes[i].GetComponent<Image>().enabled = true; // Enable Image
            scoreBoxes[i].GetComponent<Text>().enabled = true;
            scoreBoxes[i].GetComponent<Text>().text = GameMaster.activePlayers[i].GetPScore().ToString();
            if (colorToCheck == Color.red)
                spriteBoxes[i].GetComponent<Animator>().runtimeAnimatorController = redAnim as RuntimeAnimatorController; // Pop in requested animation
            if (colorToCheck == Color.green)
                spriteBoxes[i].GetComponent<Animator>().runtimeAnimatorController = greenAnim as RuntimeAnimatorController; // Pop in requested animation
            if (colorToCheck == Color.blue)
                spriteBoxes[i].GetComponent<Animator>().runtimeAnimatorController = blueAnim as RuntimeAnimatorController; // Pop in requested animation
            if (colorToCheck == Color.yellow)
                spriteBoxes[i].GetComponent<Animator>().runtimeAnimatorController = yellowAnim as RuntimeAnimatorController; // Pop in requested animation
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}