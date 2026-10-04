using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGrab : MonoBehaviour
{
    private List<GameObject> currentlyGrabbed = new List<GameObject>();
    public Elevator Elevator;

    private void Start()
    {
        Elevator = transform.parent.GetComponent<Elevator>();
    }

    void OnCollisionStay(Collision other)
    {
        if (Elevator.GiveCurrentMovement() == movementStyle.Sideways)
        {
            currentlyGrabbed.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
        }
        if (Elevator.GiveCurrentMovement() == movementStyle.Upwards)
        {
            currentlyGrabbed.Remove(other.gameObject);
            other.gameObject.transform.SetParent(null);
        }
    }

    void OnCollisionExit(Collision other)
    {
        currentlyGrabbed.Remove(other.gameObject);
        other.gameObject.transform.SetParent(null);
    }
}
