using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum movementStyle
{
    Upwards, Sideways, Angled
}

public class Elevator : MonoBehaviour
{
    public float speed;
    public float[] distance;
    public float waitingTime;
    public movementStyle[] movementStyles;
    public GameObject elevatorMovement;
    public GameObject elevatorObject;
    public Vector3 railingConstructionLocation = new Vector3(0,0,0);
    public int currentRailing=0;
    public bool goingForward = true;
    private List<IElevatorBehaviour> currentMovement = new List<IElevatorBehaviour>();
    private bool currentlyFrozen = false;

    public void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        foreach (float i in distance)
        {
            if (movementStyles[currentRailing] == movementStyle.Upwards)
            {
                currentMovement.Add(this.gameObject.AddComponent<UpwardsMovement>());
                currentMovement[currentRailing].CreateRailing(this);
            }
            else if (movementStyles[currentRailing] == movementStyle.Sideways)
            {
                currentMovement.Add(this.gameObject.AddComponent<SidewaysMovement>());
                currentMovement[currentRailing].CreateRailing(this);
            }
            currentRailing++;
        }
        currentRailing = 0;
    }

    public movementStyle GiveCurrentMovement()
    {
        if (currentRailing >= currentMovement.Count)
        {
            currentRailing = currentMovement.Count - 1;
            goingForward = false;
        }
        if (currentRailing < 0)
        {
            currentRailing = 0;
            goingForward = true;
        }
        return movementStyles[currentRailing];
    }

    public void FixedUpdate()
    {
        if (currentRailing >= currentMovement.Count)
        {
            currentRailing = currentMovement.Count - 1;
            goingForward = false;
        }
        if (currentRailing < 0)
        {
            currentRailing = 0;
            goingForward = true;
        }
        if (!currentlyFrozen)
            currentMovement[currentRailing].Move(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Unpause();
        }
    }

    void Pause()
    {
        currentlyFrozen = true;
    }

    void Unpause()
    {
        currentlyFrozen = false;
    }
}
