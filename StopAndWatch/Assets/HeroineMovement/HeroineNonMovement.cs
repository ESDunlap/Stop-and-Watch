using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeroineNonMovement : MonoBehaviour
{
    private InputManager _inputManager;
    private bool timeStopped = false;
    private float restartTimer = 0f;

    void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }
    void Update()
    {
        if (_inputManager.getPause())
        {
            if (timeStopped)
            {
                TimeBus.Publish(TimeType.UNPAUSE);
                timeStopped = false;
            }
            else
            {
                TimeBus.Publish(TimeType.PAUSE);
                timeStopped = true;
            }
        }

        if (_inputManager.getRestarting())
        {
            restartTimer += Time.deltaTime;
            if (restartTimer > 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            restartTimer = 0f;
        }
    }
}
