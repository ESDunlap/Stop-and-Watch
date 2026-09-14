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
    void Update()
    {
        if (_heroineController)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _heroineController.rigidBody.AddForce(Vector3.up * _heroineController.jumpHeight, ForceMode.Impulse);
                _heroineController.Jumping();
                _heroineController = null;
            }
            else if (!Physics.Raycast(ray, 3.0f))
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
