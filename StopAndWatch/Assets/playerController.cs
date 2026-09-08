using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour
{
    public Rigidbody playerBody;
    public float movementForce = 1000f;
    public float maxSpeed = 10f;
    // Update is called once per frame


    void Update()
    {
        float forwardSpeed = playerBody.linearVelocity.z;
        float sideSpeed = playerBody.linearVelocity.x;
        Debug.Log(forwardSpeed);
        Debug.Log((forwardSpeed <= maxSpeed));
        if (Input.GetKey(KeyCode.W) && (forwardSpeed < maxSpeed))
        {
            playerBody.AddForce(Vector3.forward * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.S) && (-forwardSpeed < maxSpeed))
        {
            playerBody.AddForce(Vector3.back * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.D) && (sideSpeed < maxSpeed))
        {
            playerBody.AddForce(Vector3.right * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.A) && (-sideSpeed < maxSpeed))
        {
            playerBody.AddForce(Vector3.left * Time.deltaTime * movementForce);
        }
    }
}
