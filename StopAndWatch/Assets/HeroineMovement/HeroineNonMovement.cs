using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeroineNonMovement : MonoBehaviour
{
    private bool timeStopped = false;
    private float restartTimer = 0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
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

        if (Input.GetKey(KeyCode.R))
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
