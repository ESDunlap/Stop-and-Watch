using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightFlipText : MonoBehaviour
{
    private InputManager _inputManager;
    public TextMeshProUGUI text;
    void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    void Update()
    {
        if (!_inputManager.currentRightClickStatus())
        {
            text.text = "Enabled";
        }
        else
        {
            text.text = "Disabled";
        }
    }
}
