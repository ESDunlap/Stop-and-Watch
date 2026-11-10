using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource birds;
    [SerializeField] private AudioSource pause;
    [SerializeField] private AudioSource  unpause;
    [SerializeField] private AudioMixer audioMixer;
    private float currentPitch;
    private bool currentlyPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        birds.Play();
    }

    private void OnDisable()
    {
        TimeBus.Unsubscribe(TimeType.PAUSE, Pause);
        TimeBus.Unsubscribe(TimeType.UNPAUSE, Unpause);
    }

    private void Update()
    {
        audioMixer.GetFloat("ClockBackgroundPitch", out currentPitch);
        if (currentlyPaused && (currentPitch > 0))
        {
            currentPitch -= Time.deltaTime/3;
            if (currentPitch < 0)
                currentPitch = 0;
            audioMixer.SetFloat("ClockBackgroundPitch", currentPitch);
        }
        else if (!currentlyPaused && (currentPitch < 2))
        {
            currentPitch += Time.deltaTime*4;
            if (currentPitch > 1)
                currentPitch = 1;
            audioMixer.SetFloat("ClockBackgroundPitch", currentPitch);
        }
    }

    private void Pause()
    {
        currentPitch = 1;
        pause.Play();
        unpause.Stop();
        currentlyPaused = true;
    }

    private void Unpause()
    {
        currentPitch = 1;
        unpause.Play();
        unpause.time = 2f;
        pause.Stop();
        currentlyPaused = false;
    }
}
