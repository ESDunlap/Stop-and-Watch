using UnityEngine;

public class HeroineSprintingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _heroineController.currentSpeed = _heroineController.runningSpeed;
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
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                _heroineController.Standing();
                _heroineController = null;
            }
            /*else if (Input.GetKeyDown(KeyCode.S))
            {
                _heroineController.Ducking();
                _heroineController = null;
            }*/
        }
    }
}
