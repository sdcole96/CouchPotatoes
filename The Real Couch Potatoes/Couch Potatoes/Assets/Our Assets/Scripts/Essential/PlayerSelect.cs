using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public int playerNum = -1;
    public GameObject[] potatoes;
    private int[] playerSpecificTater;
    public Text playerJoinText; // Player has joined the game textbox
    public Text startText; // Press start to begin textbox
    public Text[] pressATextBoxes;
	public Image[] spriteImages;
    private Color[] colorArray;
    public ArrayList remainingSprites = new ArrayList();
	public GameObject colorSelector;

    public bool playerJoined1 = false;
    public bool playerJoined2 = false;
    public bool playerJoined3 = false;
    public bool playerJoined4 = false;
    public bool playerJoined5 = false;
    public bool playerJoined6 = false;
    public bool playerJoined7 = false;
    public bool playerJoined8 = false;

    private bool isPressStartCoroutineStarted = false;

    // Use this for initialization
    void Start()
    {
        // Set your colors here;
        colorArray = new Color[4];
        colorArray[0] = Color.red;
        colorArray[1] = Color.green;
        colorArray[2] = Color.blue;
        colorArray[3] = Color.yellow;

        // Tater to Player linking
        playerSpecificTater = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        //        if (gamepad.getStartButton(ButtonQuery.Down) && GameMaster.activePlayers.Count < 4)
        //        {
        //
        //            playerNum = GameMaster.activePlayers.Count;
        //        }
        // Show the "Press Start to begin" text
        if (!isPressStartCoroutineStarted && GameMaster.activePlayers.Count == 2)
        {
            isPressStartCoroutineStarted = true;
            StartCoroutine("pressStartToBegin");
        }

        if (GamePad.GetButton(CButton.A, PlayerIndex.One) || GamePad.GetButton(PSButton.Cross, PlayerIndex.One))
        {
            // Player Join
            if (GameMaster.activePlayers.Count < 4 && !playerJoined1)
            {
                spriteImages[GameMaster.activePlayers.Count].gameObject.SetActive(true);
                pressATextBoxes[GameMaster.activePlayers.Count].enabled = false;
                DropTater();
                playerSpecificTater[0] = GameMaster.activePlayers.Count; // Index reference (for the below Player Jump!) to show which tater belongs to this player
                ColorSelect(PlayerIndex.One);
                PlayerAudio();
                PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.One);
                newPlayer.SetPColor(colorArray[GameMaster.activePlayers.Count]); // Set the color for the player, based on when they joined the game
                GameMaster.activePlayers.Add(newPlayer);
                StartCoroutine(showPlayerJoined(GameMaster.activePlayers.Count, colorArray[GameMaster.activePlayers.Count - 1]));
                playerJoined1 = true;
                Debug.Log("Controller 1");
            }
            // Player Jump!
            else if (playerJoined1)
            {
                JumpTater(potatoes[playerSpecificTater[0]]);
            }
            
        }
        else if (GamePad.GetButton(CButton.A, PlayerIndex.Two) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Two))
        {
            // Player Join
            if (GameMaster.activePlayers.Count < 4 && !playerJoined2)
            {
                spriteImages[GameMaster.activePlayers.Count].gameObject.SetActive(true);
                pressATextBoxes[GameMaster.activePlayers.Count].enabled = false;
                DropTater();
                playerSpecificTater[1] = GameMaster.activePlayers.Count; // Index reference (for the below Player Jump!) to show which tater belongs to this player
                ColorSelect(PlayerIndex.Two);
                PlayerAudio();
                PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Two);
                newPlayer.SetPColor(colorArray[GameMaster.activePlayers.Count]); // Set the color for the player, based on when they joined the game
                GameMaster.activePlayers.Add(newPlayer);
                StartCoroutine(showPlayerJoined(GameMaster.activePlayers.Count, colorArray[GameMaster.activePlayers.Count - 1]));
                playerJoined2 = true;
                Debug.Log("Controller 2");
            }
            // Player Jump!
            else if (playerJoined2)
            {
                JumpTater(potatoes[playerSpecificTater[1]]);
            }
        }
        else if (GamePad.GetButton(CButton.A, PlayerIndex.Three) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Three))
        {
            // Player Join
            if (GameMaster.activePlayers.Count < 4 && !playerJoined3) {
                spriteImages[GameMaster.activePlayers.Count].gameObject.SetActive(true);
                pressATextBoxes[GameMaster.activePlayers.Count].enabled = false;
                DropTater();
                playerSpecificTater[2] = GameMaster.activePlayers.Count; // Index reference (for the below Player Jump!) to show which tater belongs to this player
                ColorSelect(PlayerIndex.Three);
                PlayerAudio();
                PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Three);
                newPlayer.SetPColor(colorArray[GameMaster.activePlayers.Count]); // Set the color for the player, based on when they joined the game
                GameMaster.activePlayers.Add(newPlayer);
                StartCoroutine(showPlayerJoined(GameMaster.activePlayers.Count, colorArray[GameMaster.activePlayers.Count - 1]));
                playerJoined3 = true;
                Debug.Log("Controller 3");
            }
            // Player Jump!
            else if (playerJoined3)
            {
                JumpTater(potatoes[playerSpecificTater[2]]);
            }
            
        }
        else if (GamePad.GetButton(CButton.A, PlayerIndex.Four) || GamePad.GetButton(PSButton.Cross, PlayerIndex.Four))
        {
            // Player Join
            if (GameMaster.activePlayers.Count < 4 && !playerJoined4)
            {
                spriteImages[GameMaster.activePlayers.Count].gameObject.SetActive(true);
                pressATextBoxes[GameMaster.activePlayers.Count].enabled = false;
                DropTater();
                playerSpecificTater[3] = GameMaster.activePlayers.Count; // Index reference (for the below Player Jump!) to show which tater belongs to this player
                ColorSelect(PlayerIndex.Four);
                PlayerAudio();
                PlayerClass newPlayer = new PlayerClass(GameMaster.activePlayers.Count, PlayerIndex.Four);
                newPlayer.SetPColor(colorArray[GameMaster.activePlayers.Count]); // Set the color for the player, based on when they joined the game
                GameMaster.activePlayers.Add(newPlayer);
                StartCoroutine(showPlayerJoined(GameMaster.activePlayers.Count, colorArray[GameMaster.activePlayers.Count - 1]));
                playerJoined4 = true;
                Debug.Log("Controller 4");
            }
            // Player Jump!
            else if (playerJoined4)
            {
                JumpTater(potatoes[playerSpecificTater[3]]);
            }
            
        }
       
    }

    public void DropTater()
    {
		potatoes[GameMaster.activePlayers.Count].GetComponent<Rigidbody>().useGravity = true;
    }
    public void JumpTater(GameObject tater)
    {
        //tater.transform.Translate(Vector3.up * 20 * Time.deltaTime, Space.World);
        if (Physics.Raycast(tater.transform.position, -Vector3.up, 2f))
            tater.GetComponent<Rigidbody>().AddForce(new Vector3(0, 30, 0));
            
    }

    public void PlayerAudio()
	{
		int playerNum = GameMaster.activePlayers.Count + 1;
		GameObject.Find ("Player " + playerNum).GetComponent<AudioSource> ().volume = 1;
	}

	public void ColorSelect(PlayerIndex pi)
	{
		GameObject colSel = Instantiate (colorSelector);
		ColorSelect cs = colSel.GetComponent<ColorSelect>();
		cs.controllerNum = pi;
		cs.playerNum = GameMaster.activePlayers.Count;
	}

    IEnumerator showPlayerJoined(int playerNumber, Color colorName)
    {
        //Show text
        playerJoinText.enabled = true;
        playerJoinText.color = colorName;
        playerJoinText.text = "Player #" + playerNumber + " has joined the game";
        // Wait 5 seconds
        yield return new WaitForSeconds(5);
        // Hide Text
        playerJoinText.enabled = false;
    }

    IEnumerator pressStartToBegin()
    {
        while (true)
        {
            startText.enabled = true;
            yield return new WaitForSeconds(0.6f);
            startText.enabled = false;
            yield return new WaitForSeconds(0.6f);
        }

    }
}
