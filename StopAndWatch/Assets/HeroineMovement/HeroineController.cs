using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroineController : MonoBehaviour
{
    public float duckingSpeed = 1.0f;
    public float walkingSpeed = 2.0f;
    public float runningSpeed = 4.0f;
    public float fallingSpeed = 8.0f;
    public float diveForce = 20f;
    public float jumpHeight = 8.0f;
    public float diveHeight = 4f;
    public float landingTime = 0.5f;
    public float diveTime = 0.5f;
    public float rotateSpeed = 10f;
    public float maxSpeed;
    public bool dive = false;
    public Rigidbody rigidBody;
    public Transform heroine;

    public float currentSpeed;

    private IHeroineState _standingState, _sprintingState, _duckingState, _jumpingState, _fallingState, _divingState, _landingState;
    private HeroineStateContext _heroineStateContext;
    private float vInput;
    private float hInput;
    private float turnInput;

    private void Start()
    {
        _heroineStateContext = new HeroineStateContext(this);
        _standingState = gameObject.AddComponent<HeroineStandingState>();
        _sprintingState = gameObject.AddComponent<HeroineSprintingState>();
        _duckingState = gameObject.AddComponent<HeroineDuckingState>();
        _jumpingState = gameObject.AddComponent<HeroineJumpingState>();
        _fallingState = gameObject.AddComponent<HeroineFallingState>();
        _divingState = gameObject.AddComponent<HeroineDivingState>();
        _landingState = gameObject.AddComponent<HeroineLandingState>();

        _heroineStateContext.Transition(_standingState);
    }

    private void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical") * currentSpeed;
        hInput = Input.GetAxis("Horizontal") * currentSpeed;

        if (Input.GetKey(KeyCode.E))
            turnInput = 1 * rotateSpeed;
        else if (Input.GetKey(KeyCode.Q))
            turnInput = -1 * rotateSpeed;
        else
            turnInput = 0;

        Vector3 rotation = Vector3.up * turnInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);


        if (dive)
        {
            Vector3 diveDirection = new Vector3(Input.GetAxis("Horizontal") * diveForce, diveHeight , Input.GetAxis("Vertical") * diveForce);
            rigidBody.linearVelocity = new Vector3(0,0,0);
            rigidBody.AddRelativeForce(diveDirection);
            dive = false;
        }

        if((rigidBody.linearVelocity.x * Input.GetAxis("Vertical")) < maxSpeed)
            rigidBody.AddForce(this.transform.forward * Time.fixedDeltaTime * vInput);
        if ((rigidBody.linearVelocity.z * Input.GetAxis("Horizontal")) < maxSpeed)
            rigidBody.AddForce(this.transform.right * Time.fixedDeltaTime * hInput);

        rigidBody.MoveRotation(rigidBody.rotation * angleRot);
    }

    public void Standing()
    {
        _heroineStateContext.Transition(_standingState);
    }

    public void Sprinting()
    {
        _heroineStateContext.Transition(_sprintingState);
    }

    public void Ducking()
    {
        _heroineStateContext.Transition(_duckingState);
    }

    public void Jumping()
    {
        _heroineStateContext.Transition(_jumpingState);
    }

    public void Falling()
    {
        _heroineStateContext.Transition(_fallingState);
    }

    public void Diving()
    {
        _heroineStateContext.Transition(_divingState);
    }

    public void Landing()
    {
        _heroineStateContext.Transition(_landingState);
    }
}
