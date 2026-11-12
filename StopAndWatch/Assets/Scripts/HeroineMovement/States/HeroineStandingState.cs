using UnityEngine;
using System;
using System.Collections;

public class HeroineStandingState : MonoBehaviour, IHeroineState
{
    private InputManager _inputManager;
    private HeroineController _heroineController;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _inputManager = FindFirstObjectByType<InputManager>();
        _heroineController.currentSpeed = _heroineController.walkingSpeed;
        _heroineController.gameObject.GetComponent<CapsuleCollider>().height = 2;
    }

    void FixedUpdate()
    {
        if (_heroineController)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (_inputManager.getJumping())
            {
                _heroineController.rigidBody.AddForce(Vector3.up * _heroineController.jumpHeight, ForceMode.Impulse);
                _heroineController.Jumping();
                _heroineController = null;
            }
            else if (_heroineController.rigidBody.linearVelocity.y < -5f)
            {
                _heroineController.Jumping();
                _heroineController = null;
            }
            else if (_inputManager.getRunning())
            {
                _heroineController.Sprinting();
                _heroineController = null;
            }
        }
    }
}
