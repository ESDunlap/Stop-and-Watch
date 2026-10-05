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
        if (Elevator.GiveCurrentMovement() == movementStyle.Sideways || Elevator.goingForward == true)
        {
            currentlyGrabbed.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
        }
        else if (currentlyGrabbed.Contains(other.gameObject))
        {
            currentlyGrabbed.Remove(other.gameObject);
            other.gameObject.transform.SetParent(null);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (currentlyGrabbed.Contains(other.gameObject))
        {
            currentlyGrabbed.Remove(other.gameObject);
            other.gameObject.transform.SetParent(null);
        }
    }
}
