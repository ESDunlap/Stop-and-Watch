using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private InputManager _inputManager;
    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.disableEscape();
    }
}
