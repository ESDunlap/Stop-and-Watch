using UnityEngine;

public enum movementStyle
{
    Upwards, Sideways, Angled
}

public class Elevator : MonoBehaviour
{
    public float speed;
    public float distance;
    public float waitingTime;
    public movementStyle movementStyle;
    public Vector3 startPosition;
    public GameObject elevatorHub;
    private GameObject railings;
    private IElevatorBehaviour currentMovement;
    private bool currentlyFrozen = false;
    private Collider[] childColliders;

    public void Awake()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        if(movementStyle == movementStyle.Upwards)
        {
            railings = GameObject.CreatePrimitive(PrimitiveType.Cube);
            railings.transform.parent = transform;
            railings.transform.localPosition = new Vector3(0, distance/2, elevatorHub.transform.localScale.z/2);
            railings.transform.localScale = new Vector3(1, distance, 0.5f);
            startPosition = elevatorHub.transform.position;
            currentMovement = this.gameObject.AddComponent<UpwardsMovement>();
        }
        else if (movementStyle == movementStyle.Sideways)
        {
            railings = GameObject.CreatePrimitive(PrimitiveType.Cube);
            railings.transform.parent = transform;
            railings.transform.localPosition = new Vector3(distance/2, 1, elevatorHub.transform.localScale.z/2);
            railings.transform.localScale = new Vector3(distance, 1, 0.5f);
            startPosition = elevatorHub.transform.position;
            currentMovement = this.gameObject.AddComponent<SidewaysMovement>();
        }
    }

    public void FixedUpdate()
    {
        if (!currentlyFrozen)
            currentMovement.Move(this);
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
