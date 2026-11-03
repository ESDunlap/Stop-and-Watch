using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMixer audioMixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        PauseMusic();
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
