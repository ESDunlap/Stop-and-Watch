using Unity.VisualScripting;
using UnityEngine;

public class SidewaysMovement : MonoBehaviour, IElevatorBehaviour
{
    private float speed;
    private bool goingRight = true;
    private float timeToWait;
    private float timeWaited = 100f;
    private Vector3 startPosition;
    private GameObject railings;

    public void CreateRailing(Elevator elevator)
    {
        railings = GameObject.CreatePrimitive(PrimitiveType.Cube);
        railings.transform.parent = transform;
        railings.transform.localPosition = elevator.railingConstructionLocation + new Vector3(elevator.distance[elevator.currentRailing] / 2, 0, elevator.elevatorHub.transform.localScale.z / 2);
        railings.transform.localScale = new Vector3(elevator.distance[elevator.currentRailing], 1, 0.5f);
        startPosition = elevator.railingConstructionLocation + elevator.elevatorHub.transform.position;
        elevator.railingConstructionLocation += new Vector3(elevator.distance[elevator.currentRailing], 0, 0);
    }

    public void Move(Elevator elevator)
    {
        speed = elevator.speed;
        timeToWait = elevator.waitingTime;
        Vector3 endPosition = startPosition + new Vector3(elevator.distance[elevator.currentRailing], 0, 0);

        if (timeWaited < timeToWait)
        {
            timeWaited += Time.fixedDeltaTime;
            if (timeWaited > timeToWait)
            {
                if (!goingRight)
                    elevator.currentRailing++;
                else
                    elevator.currentRailing--;
            }
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
