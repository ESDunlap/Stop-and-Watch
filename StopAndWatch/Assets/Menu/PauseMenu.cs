using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMixer audioMixer;
    private void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
    }
    void Update()
    {
        if (_inputManager.getEscape() && Time.timeScale != 0)
        {
            Pause();
        }
    }

    void Pause()
    {
        _inputManager.pauseControls();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        PauseMusic();
        Debug.Log("Running");
    }

    void PauseMusic()
    {
        audioMixer.SetFloat("MasterPitch", 0);
    }

}
