using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ButtonType
{
    FORWARD,
    BACKWARD,
    RIGHT,
    LEFT,
    JUMP,
    PAUSE,
    RESTART,
    ESCAPE
}

public class InputBus : MonoBehaviour
{
    private static readonly IDictionary<ButtonType, UnityEvent>
    Events = new Dictionary<ButtonType, UnityEvent>();

    public static void Subscribe(ButtonType eventType, UnityAction listener)
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

    public static void Unsubscribe(ButtonType type, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void Publish(ButtonType type)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
            thisEvent.Invoke();
    }
}
