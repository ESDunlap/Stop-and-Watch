using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum tutorialChecks
{
    noCheck,
    movementCheck,
    sprintCheck,
    turnCheck,
    pauseCheck,
    jumpCheck,
    unpauseCheck
}

public class HeroineTutorial : MonoBehaviour
{
    private tutorialChecks currentTutorial = tutorialChecks.movementCheck;
    private Quaternion currentAngle;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject checkMark;
    [SerializeField] private GameObject sprintCheck;
    [SerializeField] private GameObject turnCheck;
    [SerializeField] private GameObject pauseCheck;
    [SerializeField] private GameObject jumpCheck;
    [SerializeField] private GameObject unpauseCheck;
    [SerializeField] private TextMeshProUGUI _text;
    private bool currentlyPaused = false;
    private void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        currentAngle = transform.rotation;

    }

    private void Pause()
    {
        currentlyPaused = true;
    }

    private void Unpause()
    {
        currentlyPaused = false;
    }


    void Update()
    {
        if (currentTutorial == tutorialChecks.movementCheck)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }
        else if (currentTutorial == tutorialChecks.sprintCheck)
        {
            if (GetComponent<HeroineController>().currentSpeed == GetComponent<HeroineController>().runningSpeed)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }
        else if (currentTutorial == tutorialChecks.turnCheck)
        {
            if (currentAngle != transform.rotation)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }
        else if (currentTutorial == tutorialChecks.pauseCheck)
        {
            if (currentlyPaused)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }
        else if (currentTutorial == tutorialChecks.jumpCheck)
        {
            if (GetComponent<HeroineController>().dive)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }
        else if (currentTutorial == tutorialChecks.unpauseCheck)
        {
            if (!currentlyPaused)
            {
                checkMark.SetActive(true);
                currentTutorial = tutorialChecks.noCheck;
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == sprintCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Hold down Shift in order to sprint";
            currentTutorial = tutorialChecks.sprintCheck;
            sprintCheck.SetActive(false);
        }
        else if (collision.gameObject == turnCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Use the arrow keys or right click to turn";
            currentTutorial = tutorialChecks.turnCheck;
            turnCheck.SetActive(false);
        }
        else if (collision.gameObject == pauseCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Press T in order to pause time";
            currentTutorial = tutorialChecks.pauseCheck;
            pauseCheck.SetActive(false);
        }
        else if (collision.gameObject == jumpCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Press Space to jump. Press it again to dive";
            currentTutorial = tutorialChecks.jumpCheck;
            jumpCheck.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "TimeWall")
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Press T again in order to unpause time";
            currentTutorial = tutorialChecks.unpauseCheck;
        }
    }
}
