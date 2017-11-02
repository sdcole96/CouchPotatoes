using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public int playerNum = 1;
    public XboxController gamepad = new XboxController();

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (gamepad.getAButton(ButtonQuery.Down) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("ShootingGalleryOcean");
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("ShootingGalleryOcean");
    }
}
