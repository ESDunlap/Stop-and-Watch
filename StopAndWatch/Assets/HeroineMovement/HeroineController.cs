using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HeroineController : MonoBehaviour
{
    public float walkingSpeed = 2.0f;
    public float runningSpeed = 4.0f;
    public float diveForce = 20f;
    public float jumpHeight = 8.0f;
    public float diveHeight = 8f;
    public float landingTime = 0.5f;
    public float diveTime = 0.5f;
    public float rotateSpeed = 10f;
    public float maxSpeed;
    public bool dive = false;
    public Rigidbody rigidBody;
    public Transform heroine;

    public float currentSpeed;
    public float sensitivity = 500f;

    private IHeroineState _standingState, _sprintingState, _duckingState, _jumpingState, _fallingState, _divingState, _landingState;
    private HeroineStateContext _heroineStateContext;
    private float vInput;
    private float hInput;
    private Material heroineMaterial;

    //Unused in current build
    public float duckingSpeed = 1.0f;
    public float fallingSpeed = 8.0f;

    private void Start()
    {
        _heroineStateContext = new HeroineStateContext(this);
        _standingState = gameObject.AddComponent<HeroineStandingState>();
        _sprintingState = gameObject.AddComponent<HeroineSprintingState>();
        _jumpingState = gameObject.AddComponent<HeroineJumpingState>();
        _divingState = gameObject.AddComponent<HeroineDivingState>();
        _landingState = gameObject.AddComponent<HeroineLandingState>();


        //Unused in current build
        //_duckingState = gameObject.AddComponent<HeroineDuckingState>();
        //_fallingState = gameObject.AddComponent<HeroineFallingState>();

        _heroineStateContext.Transition(_standingState);
    }

    private void FixedUpdate()
    {
        //Gathering inputs
        vInput = Input.GetAxis("Vertical") * currentSpeed;
        hInput = Input.GetAxis("Horizontal") * currentSpeed;

        //If the dive is used
        if (dive)
        {
            Vector3 diveDirection = new Vector3(Input.GetAxis("Horizontal") * diveForce, 100, Input.GetAxis("Vertical") * diveForce);
            rigidBody.linearVelocity = new Vector3(0, 0, 0);
            Debug.Log(diveDirection);
            rigidBody.AddRelativeForce(diveDirection);
            dive = false;
        }

        if ((rigidBody.linearVelocity.x * Input.GetAxis("Vertical")) < maxSpeed)
            rigidBody.AddForce(this.transform.forward * Time.fixedDeltaTime * vInput);
        if ((rigidBody.linearVelocity.z * Input.GetAxis("Horizontal")) < maxSpeed)
            rigidBody.AddForce(this.transform.right * Time.fixedDeltaTime * hInput);

        //Using inputs to move
    }


    //Camera x movement
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rotation = Vector3.up * Input.GetAxis("Mouse X");
            Quaternion angleRot = Quaternion.Euler(rotation * Time.deltaTime * sensitivity);
            rigidBody.MoveRotation(rigidBody.rotation * angleRot);
        }
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
