using System.Collections;
using UnityEngine;

public class RegularObject : MonoBehaviour
{
    private Rigidbody rb;
    private float startingWeight;
    private float startingDamping;
    private float startingAngleDamping;
    private bool currentlyPaused = false;
    private bool unpauseTest = false;
    private Material _material;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        startingWeight = rb.mass;
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        startingDamping = rb.linearDamping;
        startingAngleDamping = rb.angularDamping;
        _material.DisableKeyword("_EMISSION");
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
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            unpauseTest = true;
        }
    }

    private void LateUpdate()
    {
        if (unpauseTest)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            unpauseTest = false;
        }
    }

    private void Pause()
    {
        _material.EnableKeyword("_EMISSION");
        startingWeight = rb.mass;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.mass = 0.01f;
        rb.linearDamping = 1000000f;
        rb.angularDamping = 1000000f;
        currentlyPaused = true;
    }

    private void Unpause()
    {
        rb.mass = startingWeight;
        rb.AddForce(0f, 0.1f, 0f);
        rb.constraints = RigidbodyConstraints.None;
        currentlyPaused = false;
        _material.DisableKeyword("_EMISSION");
        StartCoroutine(Unfreeze());
    }

    IEnumerator Unfreeze()
    {
        yield return new WaitForSeconds(0.3f);
        if (!currentlyPaused)
        {
            rb.linearDamping = startingDamping;
            rb.angularDamping = startingAngleDamping;
        }
    }
}
