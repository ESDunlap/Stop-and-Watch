using UnityEngine;

public class SidewaysMovement : MonoBehaviour, IElevatorBehaviour
{
    private float speed;
    private bool goingRight = true;
    private float timeToWait;
    private float timeWaited = 100f;
    public void Move(Elevator elevator)
    {
        speed = elevator.speed;
        timeToWait = elevator.waitingTime;
        Vector3 startPosition = elevator.startPosition;
        Vector3 endPosition = elevator.startPosition + new Vector3(elevator.distance, 0, 0);

        if (timeWaited < timeToWait)
        {
            timeWaited += Time.fixedDeltaTime;
        }
        else if (goingRight)
        {
            elevator.elevatorHub.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            if (elevator.elevatorHub.transform.position.x > endPosition.x)
            {
                elevator.elevatorHub.transform.position = endPosition;
                goingRight = false;
                timeWaited = 0;
            }
        }
        else
        {
            elevator.elevatorHub.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            if (elevator.elevatorHub.transform.position.x < startPosition.x)
            {
                elevator.elevatorHub.transform.position = startPosition;
                goingRight = true;
                timeWaited = 0;
            }
        }
    }
}
