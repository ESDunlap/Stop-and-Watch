using UnityEngine;

public class RegularObject : MonoBehaviour
{
    private Rigidbody rb;
    private float startingWeight;
    private float startingDamping;
    private float startingAngleDamping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        startingWeight = rb.mass;
        startingDamping = rb.linearDamping;
        startingAngleDamping = rb.angularDamping;
    }

    private void OnDisable()
    {
        TimeBus.Unsubscribe(TimeType.PAUSE, Pause);
        TimeBus.Unsubscribe(TimeType.UNPAUSE, Unpause);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
            Unpause();
    }

    private void Pause()
    {
        rb.mass = 0f;
        rb.linearDamping = 1000000f;
        rb.angularDamping = 1000000f;
    }

    private void Unpause()
    {
        rb.mass = startingWeight;
        rb.linearDamping = startingDamping;
        rb.angularDamping = startingAngleDamping;
        rb.AddForce(0.1f, 0.1f, 0.1f);
    }
}
