using UnityEngine;
using System;
using System.Collections;

public class HeroineStandingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _heroineController.heroine.localScale = new Vector3(1, 1, 1);
        _heroineController.currentSpeed = _heroineController.walkingSpeed;
        _heroineController.gameObject.GetComponent<CapsuleCollider>().height = 2;
    }

    void FixedUpdate()
    {
        if (_heroineController)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Input.GetKey(KeyCode.Space))
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
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                _heroineController.Sprinting();
                _heroineController = null;
            }
        }
    }
}
