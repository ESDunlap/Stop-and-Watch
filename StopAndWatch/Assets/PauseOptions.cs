using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private bool currentlyMainPause = true;
    private List<GameObject> allMenus = new List<GameObject>();
    [SerializeField] private GameObject mainMenu;
    [SerializeField]  private GameObject settingsMenu;
    [SerializeField] private GameObject levelSelectMenu;

    private void Awake()
    {
        allMenus.Add(mainMenu);
        allMenus.Add(settingsMenu);
        allMenus.Add(levelSelectMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentlyMainPause)
        {
            Unpause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenuChange();
        }
    }

    public void mainMenuChange()
    {
        foreach (GameObject menu in allMenus)
        {
            menu.SetActive(false);
        }
        mainMenu.SetActive(true);
        currentlyMainPause = true;
    }

    public void settingsMenuChange()
    {
        foreach (GameObject menu in allMenus)
        {
            menu.SetActive(false);
        }
        settingsMenu.SetActive(true);
        currentlyMainPause = false;
    }

    public void levelSelectMenuChange()
    {
        foreach (GameObject menu in allMenus)
        {
            menu.SetActive(false);
        }
        levelSelectMenu.SetActive(true);
        currentlyMainPause = false;
        Debug.Log("This Runs");
    }

    void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        UnpauseMusic();
    }

    void UnpauseMusic()
    {
        audioMixer.SetFloat("MasterPitch", 1);
    }
}
