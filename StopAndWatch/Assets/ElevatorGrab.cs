using NUnit.Framework;
using UnityEngine;

public class ElevatorGrab : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.SetParent(transform);
    }

    void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
