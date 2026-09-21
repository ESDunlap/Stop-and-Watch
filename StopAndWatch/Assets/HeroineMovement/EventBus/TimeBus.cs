using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public enum TimeType
{
    PAUSE, UNPAUSE
}

public class TimeBus : MonoBehaviour
{
    private static readonly IDictionary<TimeType, UnityEvent>
    Events = new Dictionary<TimeType, UnityEvent>();

    public static void Subscribe(TimeType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
            thisEvent.AddListener(listener);
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(TimeType type, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void Publish(TimeType type)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
            thisEvent.Invoke();
    }
}
