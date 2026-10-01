using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class UpwardsMovement : MonoBehaviour, IElevatorBehaviour
{
    private float speed;
    private bool goingUp = true;
    private float timeToWait;
    private float timeWaited = 100f;
    private Vector3 startPosition;
    private GameObject railings;

    public void CreateRailing(Elevator elevator)
    {
        railings = GameObject.CreatePrimitive(PrimitiveType.Cube);
        railings.transform.parent = transform;
        railings.transform.localPosition = elevator.railingConstructionLocation + new Vector3(0, elevator.distance[elevator.currentRailing] / 2, elevator.elevatorHub.transform.localScale.z / 2);
        railings.transform.localScale = new Vector3(1, elevator.distance[elevator.currentRailing], 0.5f);
        startPosition = elevator.railingConstructionLocation + elevator.elevatorHub.transform.position;
        elevator.railingConstructionLocation += new Vector3(0, elevator.distance[elevator.currentRailing], 0);
    }

    public void Move(Elevator elevator)
    {
        speed = elevator.speed;
        timeToWait = elevator.waitingTime;
        Vector3 endPosition = startPosition + new Vector3(0, elevator.distance[elevator.currentRailing], 0);

        if (timeWaited < timeToWait)
        {
            timeWaited += Time.fixedDeltaTime;
            if (timeWaited > timeToWait)
            {
                if (!goingUp)
                    elevator.currentRailing++;
                else
                    elevator.currentRailing--;
            }
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
