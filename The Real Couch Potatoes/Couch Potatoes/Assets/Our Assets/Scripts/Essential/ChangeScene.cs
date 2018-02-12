using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public int playerNum = 1;
    public XboxController gamepad = new XboxController();
	public Button currentButton;
	public Button[] buttons;

    public bool isTransitioning = false; // to indicated whether or not we will be transitioning to a new scene

    public Text player1Score;
    public Text player2Score;
    public Text player3Score;
    public Text player4Score;

    // Use this for initialization
    void Start () 
	{
		gamepad.playerNum = playerNum;
		int i = 0;
		foreach (string name in Input.GetJoystickNames()) 
		{
			Debug.Log ("index " + i + ": "+ name);
			++i;
		}

        //player1Score.text = "Player 1 Score: " + GameMaster.player1Score;
        //player2Score.text = "Player 2 Score: " + GameMaster.player2Score;
        //player3Score.text = "Player 3 Score: " + GameMaster.player3Score;
        //player4Score.text = "Player 4 Score: " + GameMaster.player4Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad.getXButton(ButtonQuery.Down))
        {
			LoadSceneSG ();
        }
		else if (gamepad.getBButton(ButtonQuery.Down))
		{
			LoadSceneBTI ();
		}
        else if (gamepad.getYButton(ButtonQuery.Down) && !isTransitioning)
        {
            Debug.Log("Ok we detach");
            isTransitioning = true;
            StartCoroutine("LoadSceneAfterTransition");
            // Temp for now. Just moving camera to TV set
            GetComponent<CameraZoom>().isDetached = true; // detach
            // Fade out
            GetComponent<fadeInFadeOut>().FadeIn();
        }
    }

    public void LoadSceneSG()
    {
        SceneManager.LoadScene("ShootingGalleryOcean");
    }

	public void LoadSceneBTI()
	{
		SceneManager.LoadScene("BreakTheIce");
	}

	public void LoadSceneMM()
	{
		SceneManager.LoadScene("MainMenu");
	}

    IEnumerator LoadSceneAfterTransition()
    {
        yield return new WaitForSeconds(1.3f);
        LoadSceneMM();

    }
}
