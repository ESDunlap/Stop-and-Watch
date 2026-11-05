using UnityEngine;
using UnityEngine.Audio;

public class ElevatorNoise : MonoBehaviour
{
    private AudioSource elevatorNoise;
    private bool paused = false;
    private float currentPitch;

    private void Awake()
    {

        elevatorNoise = gameObject.GetComponentInChildren<AudioSource>();
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    public void playSound()
    {
        if (!elevatorNoise.isPlaying)
        {
            elevatorNoise.Play();
            elevatorNoise.time = Random.RandomRange(0f, 3f);
        }
    }

    public void stopSound()
    {
        elevatorNoise.Pause();
    }

    void Pause()
    {
        paused = true;
    }

    public void Unpause()
    {
        paused = false;
    }
    private void Update()
    {
        currentPitch = elevatorNoise.pitch;
        if (paused && (currentPitch > 0))
        {
            currentPitch -= Time.deltaTime;
            if (currentPitch < 0)
                currentPitch = 0;
            elevatorNoise.pitch = currentPitch;
        }
        else if (!paused && (currentPitch < 1))
        {
            currentPitch += Time.deltaTime*2;
            if (currentPitch > 1)
                currentPitch = 1;
            elevatorNoise.pitch = currentPitch;
        }
    }
}
