using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShiftRunText : MonoBehaviour
{
    private InputManager _inputManager;
    public TextMeshProUGUI text;
    void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    void Update()
    {
        if (!_inputManager.currentRun())
        {
            text.text = "Enabled";
        }
        else
        {
            text.text = "Disabled";
        }
    }
}
