using UnityEngine;
using UnityEngine.Animations;

public class InputManager : Singleton<InputManager>
{
    //Main Inputs
    private KeyCode moveForward = KeyCode.W;
    private KeyCode moveBack = KeyCode.S;
    private KeyCode moveRight = KeyCode.D;
    private KeyCode moveLeft = KeyCode.A;
    private KeyCode jump = KeyCode.Space;
    private KeyCode pause = KeyCode.T;
    private KeyCode restart = KeyCode.R;
    private KeyCode escape = KeyCode.Escape;
    private KeyCode running = KeyCode.LeftShift;
    private KeyCode turnLeft = KeyCode.LeftArrow;
    private KeyCode turnRight = KeyCode.RightArrow;
    private KeyCode turnUp = KeyCode.UpArrow;
    private KeyCode turnDown = KeyCode.DownArrow;

    //Changed Settings
    private bool bypassButtonDown = false;
    private bool paused = false;
    private bool mouseFlip = true;
    private bool escapeDisabled = false;
    private bool rightClickSwitched = false;
    private bool runDefault = false;

    //Main Input Gathering
    public int getVerticalAxis()
    {
        if (paused)
            return 0;
        int verticalInput = 0;
        if (Input.GetKey(moveForward))
            verticalInput += 1;
        if (Input.GetKey(moveBack))
            verticalInput -= 1;
        return verticalInput;

    }

    public int getHorizontalAxis()
    {
        if (paused)
            return 0;
        int horizontalInput = 0;
        if (Input.GetKey(moveRight))
            horizontalInput += 1;
        if (Input.GetKey(moveLeft))
            horizontalInput -= 1;
        return horizontalInput;
    }

    public int getHorizontalTurningAxis()
    {
        if (paused)
            return 0;
        int horizontalTurn = 0;
        if (Input.GetKey(turnRight))
            horizontalTurn += 1;
        if (Input.GetKey(turnLeft))
            horizontalTurn -= 1;
        return horizontalTurn;
    }

    public int getVerticalTurningAxis()
    {
        if (paused)
            return 0;
        int verticalTurn = 0;
        if (Input.GetKey(turnUp))
            verticalTurn += 1;
        if (Input.GetKey(turnDown))
            verticalTurn -= 1;
        return verticalTurn;

    }

    public bool getJumping()
    {
        if (paused)
            return false;
        return Input.GetKey(jump);
    }

    public bool getRunning()
    {
        if (paused)
            return false;
        if (runDefault)
            return !Input.GetKey(running);
        return Input.GetKey(running);
    }

    public bool getPause()
    {
        if (paused)
            return false;
        return Input.GetKeyDown(pause);
    }

    public bool getRestarting()
    {
        if (paused)
            return false;
        return Input.GetKey(restart);
    }

    public bool getEscape()
    {
        if (escapeDisabled)
            return false;
        return Input.GetKeyDown(escape);
    }

    public float getMouseHorizontal()
    {
        if (paused)
            return 0;
        float XAxis = Input.GetAxis("Mouse X");
        return XAxis;
    }

    public float getMouseVertical()
    {
        if (paused)
            return 0;
        float YAxis;
        if (mouseFlip)
            YAxis = Input.GetAxis("Mouse Y");
        else
            YAxis = -Input.GetAxis("Mouse Y");
        return YAxis;
    }

    public float getMouseScroll()
    {
        if (paused)
            return 0;
        return Input.mouseScrollDelta.y;
    }

    public bool getRightClickDown()
    {
        if (rightClickSwitched)
            return !Input.GetMouseButton(1);
        return Input.GetMouseButton(1);
    }

    public bool currentMouseVertical()
    {
        return mouseFlip;
    }

    public bool currentRightClickStatus()
    {
        return rightClickSwitched;
    }

    public bool currentRun()
    {
        return runDefault;
    }

    //Changing Controls

    public void flipMouseVertical()
    {
        mouseFlip = !mouseFlip;
    }

    public void pauseControls()
    {
        paused = true;
        Debug.Log("This is running");
    }

    public void unpauseControls()
    {
        paused = false;
        Debug.Log("This Runs");
    }

    public void disableEscape()
    {
        escapeDisabled = true;
    }

    public void enableEscape()
    {
        escapeDisabled = false;
    }

    public void rightClickSwitch()
    {
        rightClickSwitched = !rightClickSwitched;
    }

    public void runSwitch()
    {
        runDefault = !runDefault;
    }
}
