using UnityEngine;

public class linearDampingFix : MonoBehaviour
{
    private Rigidbody rb;
    private float linearDampingHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        linearDampingHorizontal = rb.linearDamping;
        rb.linearDamping = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3 (rb.linearVelocity.x * (1 -  linearDampingHorizontal * Time.deltaTime),
            rb.linearVelocity.y,
            rb.linearVelocity.z * (1 - linearDampingHorizontal * Time.deltaTime));
    }
}
