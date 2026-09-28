using UnityEngine;
using System.Collections;

public class UpwardsMovement : MonoBehaviour, IElevatorBehaviour
{
    private float speed;
    private bool goingUp = true;
    private float timeToWait;
    private float timeWaited = 100f;
    public void Move(Elevator elevator)
    {
        speed = elevator.speed;
        timeToWait = elevator.waitingTime;
        Vector3 startPosition = elevator.startPosition;
        Vector3 endPosition = elevator.startPosition + new Vector3(0, elevator.distance, 0);

        if (timeWaited < timeToWait)
        {
            timeWaited += Time.fixedDeltaTime;
        }
        else if (goingUp)
        {
            elevator.elevatorHub.transform.position += new Vector3(0,speed * Time.fixedDeltaTime, 0);
            if (elevator.elevatorHub.transform.position.y > endPosition.y)
            {
                elevator.elevatorHub.transform.position = endPosition;
                goingUp = false;
                timeWaited = 0;
            }
        }
        else
        {
            elevator.elevatorHub.transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
            if (elevator.elevatorHub.transform.position.y < startPosition.y)
            {
                elevator.elevatorHub.transform.position = startPosition;
                goingUp = true;
                timeWaited = 0;
            }
        }

    }
}
