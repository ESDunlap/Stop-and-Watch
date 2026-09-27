using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void OnDisable()
    {
        TimeBus.Unsubscribe(TimeType.PAUSE, Pause);
        TimeBus.Unsubscribe(TimeType.UNPAUSE, Unpause);
    }

    private void Pause()
    {
    }

    private void PauseBird()
    {
        audioSource.Pause();
    }

    private void Unpause()
    {
    }
}
