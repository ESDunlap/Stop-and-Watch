using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlipButtonText : MonoBehaviour
{
    private InputManager _inputManager;
    public TextMeshProUGUI text;
    void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    void Update()
    {
        if (_inputManager.currentMouseVertical())
        {
            text.text = "Enabled";
        }
        else
        {
            text.text = "Disabled";
        }
    }
}
