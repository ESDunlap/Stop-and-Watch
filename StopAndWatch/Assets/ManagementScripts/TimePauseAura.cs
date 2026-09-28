using UnityEngine;
using UnityEngine.UI;

public class TimePauseAura : MonoBehaviour
{
    public GameObject aura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    void OnDisable()
    {
        TimeBus.Unsubscribe(TimeType.PAUSE, Pause);
        TimeBus.Unsubscribe(TimeType.UNPAUSE, Unpause);
    }

    void Pause()
    {
        Debug.Log("test");
        aura.SetActive(true);
    }

    void Unpause()
    {
        aura.SetActive(false);
    }
}
