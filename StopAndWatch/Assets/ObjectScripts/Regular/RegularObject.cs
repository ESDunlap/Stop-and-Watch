using System.Collections;
using UnityEngine;

public class RegularObject : MonoBehaviour
{
    private Rigidbody rb;
    private float startingWeight;
    private float startingDamping;
    private float startingAngleDamping;
    private bool currentlyPaused = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        startingWeight = rb.mass;
    }

    private void OnDisable()
    {
        TimeBus.Unsubscribe(TimeType.PAUSE, Pause);
        TimeBus.Unsubscribe(TimeType.UNPAUSE, Unpause);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && currentlyPaused)
        {
            Unpause();
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
    }

    private void Pause()
    {
        startingWeight = rb.mass;
        startingDamping = rb.linearDamping;
        startingAngleDamping = rb.angularDamping;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.mass = 0.01f;
        rb.linearDamping = 1000000f;
        rb.angularDamping = 1000000f;
        currentlyPaused = true;
    }

    private void Unpause()
    {
        rb.mass = startingWeight;
        rb.linearDamping = startingDamping;
        rb.angularDamping = startingAngleDamping;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(0f, 0.1f, 0f);
        currentlyPaused = false;
    }
}
