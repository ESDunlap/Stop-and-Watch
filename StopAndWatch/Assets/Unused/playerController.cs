using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float movementForce = 1000f;
    //public float maxSpeed = 10f;
    public float rotateSpeed = 10f;
    public float jumpForce = 10f;


    private float forwardSpeed;
    private float sideSpeed;
    private float vInput;
    private float hInput;
    private float turnInput;
    // Update is called once per frame


    void FixedUpdate()
    {
        //Obtain player movement request
        vInput = Input.GetAxis("Vertical") * movementForce;
        hInput = Input.GetAxis("Horizontal") * movementForce;

        //Turning
        if (Input.GetKey(KeyCode.E))
            turnInput = 1 * rotateSpeed;
        else if (Input.GetKey(KeyCode.Q))
            turnInput = -1 * rotateSpeed;
        else
            turnInput = 0;

        //Jumping
        if (Input.GetKey(KeyCode.Space))
            TryJump();
        /*Debug.Log((playerBody.linearVelocity.z));
        Debug.Log((playerBody.linearVelocity.z * Input.GetAxis("Vertical")) < maxSpeed);
        if ((playerBody.linearVelocity.z * Input.GetAxis("Vertical")) < maxSpeed)
        {
            playerBody.AddForce(this.transform.forward * Time.deltaTime * vInput);
        }
        if ((playerBody.linearVelocity.x * Input.GetAxis("Horizontal")) < maxSpeed)
        {
            playerBody.AddForce(this.transform.right * Time.deltaTime * hInput);
        }*/ //old movement system

        //Calculating rotation
        Vector3 rotation = Vector3.up * turnInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        //Commit
        rigidBody.MovePosition(this.transform.position + (this.transform.forward * vInput * Time.fixedDeltaTime) + (this.transform.right * hInput * Time.fixedDeltaTime));
        rigidBody.MoveRotation(rigidBody.rotation * angleRot);
    }

    void TryJump()
    {
        // create a ray facing down
        Ray ray = new Ray(transform.position, Vector3.down);
        // shoot the raycast
        if (Physics.Raycast(ray, 1.5f))
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
