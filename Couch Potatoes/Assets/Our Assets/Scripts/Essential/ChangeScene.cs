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
}
