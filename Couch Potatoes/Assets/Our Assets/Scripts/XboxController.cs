using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController
{

	public int playerNum = -1;
    public bool isMac = false;

	public bool getAButton(ButtonQuery q)
	{
        string input = "JoystickBtnA";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

	public bool getBButton(ButtonQuery q)
	{
        string input = "JoystickBtnB";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

	public bool getYButton(ButtonQuery q)
	{
        string input = "JoystickBtnY";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

	public bool getXButton(ButtonQuery q)
	{
        string input = "JoystickBtnX";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

	public bool getRightTrigger(ButtonQuery q)
	{
        string input = "JoystickRightTrigger";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

	public bool getLeftTrigger(ButtonQuery q)
	{
        string input = "JoystickLeftTrigger";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

    public bool getStartButton(ButtonQuery q)
    {
        string input = "JoystickStart";
        if (isMac)
        {
            input = input + "Mac";
        }
        switch (q)
        {
            case ButtonQuery.Up:
                return Input.GetButtonUp(input + playerNum);
            case ButtonQuery.Down:
                return Input.GetButtonDown(input + playerNum);
            case ButtonQuery.Hold:
                return Input.GetButton(input + playerNum);
        }
        return false;
    }

    public float getAxisX(ButtonQuery q)
	{
		string input = "JoystickX";

        return Input.GetAxis (input + playerNum);
	}

	public float getAxisY(ButtonQuery q)
	{
		string input = "JoystickY";

        return Input.GetAxis (input + playerNum);
	}

}

public enum ButtonQuery
{
	Up, 
	Down, 
	Hold
}