using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UpwardsMovement : MonoBehaviour, IElevatorBehaviour
{
    private GameObject railingPrefab;
    private float speed;
    private bool goingUp = true;
    private float timeToWait;
    private float timeWaited = 100f;
    private Vector3 startPosition;
    private GameObject railings;
    private ElevatorNoise elevatorNoise;

    public void CreateRailing(Elevator elevator)
    {
        railingPrefab = Resources.Load("Railing") as GameObject;
        railings = Instantiate(railingPrefab);
        railings.transform.parent = transform;
        railings.transform.localPosition = elevator.railingConstructionLocation + new Vector3(
        0, //X
        elevator.distance[elevator.currentRailing]/2, //Y
        elevator.elevatorObject.transform.localScale.z/2); //Z
        railings.transform.localScale = new Vector3(1, elevator.distance[elevator.currentRailing], 0.5f);
        startPosition = elevator.railingConstructionLocation + elevator.elevatorObject.transform.position;
        elevator.railingConstructionLocation += new Vector3(0, elevator.distance[elevator.currentRailing], 0);
        elevator.allRailings.Add(railings);
        elevatorNoise = GetComponent<ElevatorNoise>();
    }

    public void Move(Elevator elevator)
    {
        speed = elevator.speed;
        timeToWait = elevator.waitingTime;
        Vector3 endPosition = startPosition + new Vector3(0, elevator.distance[elevator.currentRailing], 0);

        if (timeWaited < timeToWait)
        {
            elevatorNoise.stopSound();
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
            elevatorNoise.playSound();
            elevator.elevatorMovement.transform.position += new Vector3(0,speed * Time.fixedDeltaTime, 0);
            if (elevator.elevatorMovement.transform.position.y > endPosition.y)
            {
                elevator.elevatorMovement.transform.position = endPosition;
                goingUp = false;
                timeWaited = 0;
            }
        }
        else
        {
            elevatorNoise.playSound();
            elevator.elevatorMovement.transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
            if (elevator.elevatorMovement.transform.position.y < startPosition.y)
            {
                elevator.elevatorMovement.transform.position = startPosition;
                goingUp = true;
                timeWaited = 0;
            }
        }

    }
}
