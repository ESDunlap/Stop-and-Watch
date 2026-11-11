using UnityEngine;
using UnityEngine.Animations;

public class InputManager : MonoBehaviour
{
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

    private bool bypassButtonDown = false;
    private bool paused = false;
    private bool mouseFlip = true;
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
        return Input.GetMouseButton(1);
    }

    public void flipMouseVertical()
    {
        mouseFlip = !mouseFlip;
    }

    public bool currentMouseVertical()
    {
        return mouseFlip;
    }

    public void pauseControls()
    {
        paused = true;
    }

    public void unpauseControls()
    {
        paused = false;
    }

    public void disableEscape()
    {
        escape = KeyCode.None;
    }
}
