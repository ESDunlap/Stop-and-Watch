using UnityEngine;

public class SettingsInputChanges : MonoBehaviour
{
    private InputManager _inputManager;
    void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    public void flipYAxis()
    {
        _inputManager.flipMouseVertical();
    }

    public void rightClickSwitch()
    {
        _inputManager.rightClickSwitch();
    }

    public void switchRun()
    {
        _inputManager.runSwitch();
    }
}
