using UnityEngine;
using UnityEngine.Audio;

public class StartMenuPause : MonoBehaviour
{
    public InputManager _inputManager;
    public AudioMixer audioMixer;
    void Awake()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    void OnEnable()
    {
        _inputManager.pauseControls();
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        _inputManager.unpauseControls();
        Time.timeScale = 1;
    }

    void PauseMusic()
    {
        audioMixer.SetFloat("MasterPitch", 0);
    }

    void UnpauseMusic()
    {
        audioMixer.SetFloat("MasterPitch", 1);
    }

}
