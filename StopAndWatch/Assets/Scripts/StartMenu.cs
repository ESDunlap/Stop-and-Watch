using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private InputManager _inputManager;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.disableEscape();
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        string nextName = next.name;

        if (nextName != "Menu")
        {
            _inputManager.enableEscape();
        }
        else
        {
            _inputManager.disableEscape();
        }
    }
}
