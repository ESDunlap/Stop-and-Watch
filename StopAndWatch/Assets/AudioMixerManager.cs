using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    private bool currentlyPaused = false;
    private float currentPitch = 1f;

    private void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    public void Pause()
    {
        currentlyPaused = true;
    }

    public void Unpause()
    {
        currentlyPaused = false;
    }

    private void Update()
    {
        audioMixer.GetFloat("Paused", out currentPitch);
        if (currentlyPaused && (currentPitch > 0))
        {
            currentPitch -= Time.deltaTime;
            if (currentPitch < 0)
                currentPitch = 0;
            audioMixer.SetFloat("Paused", currentPitch);
        }
        else if (!currentlyPaused && (currentPitch < 1))
        {
            currentPitch += Time.deltaTime;
            if (currentPitch > 1)
                currentPitch = 1;
            audioMixer.SetFloat("Paused", currentPitch);
        }
    }
}
