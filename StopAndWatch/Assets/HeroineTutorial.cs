using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroineTutorial : MonoBehaviour
{
    private bool movementTutorial = true;
    private bool sprintTutorial = false;
    private bool turnTutorial = false;
    private bool pauseTutorial = false;
    private bool jumpTutorial = false;
    private Quaternion currentAngle;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject checkMark;
    [SerializeField] private GameObject sprintCheck;
    [SerializeField] private GameObject turnCheck;
    [SerializeField] private GameObject pauseCheck;
    [SerializeField] private GameObject jumpCheck;
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (movementTutorial)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                checkMark.SetActive(true);
                movementTutorial = false;
            }
        }
        else if (sprintTutorial)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                checkMark.SetActive(true);
                sprintTutorial = false;
            }
        }
        else if (turnTutorial)
        {
            if (currentAngle != transform.rotation)
            {
                checkMark.SetActive(true);
                turnTutorial = false;
            }
        }
        else if (pauseTutorial)
        {
            if (Input.GetKey(KeyCode.T))
            {
                checkMark.SetActive(true);
                pauseTutorial = false;
            }
        }
        else if (jumpTutorial)
        {
            if (GetComponent<HeroineController>().dive)
            {
                checkMark.SetActive(true);
                jumpTutorial = false;
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == sprintCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Hold down Shift in order to sprint";
            sprintTutorial = true;
        }
        else if (collision.gameObject == turnCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Use the arrow keys or right click to turn";
            turnTutorial = true;
            currentAngle = transform.rotation;
        }
        else if (collision.gameObject == pauseCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Press T in order to pause time";
            pauseTutorial = true;
        }
        else if (collision.gameObject == jumpCheck)
        {
            textBox.GetComponent<Animation>().Play("AddText");
            _text.text = "Press Space to jump. Press it again to dive";
            jumpTutorial = true;
        }
    }
}
