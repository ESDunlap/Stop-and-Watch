using UnityEngine;

public class HeroineJumpingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;
    float timer = 0;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        timer = 0;
    }

    void FixedUpdate()
    {
        if (_heroineController)
        {
            timer += Time.deltaTime;
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, 1.5f) && _heroineController.rigidBody.linearVelocity.y < 0 && timer > 0.1f)
            {
                _heroineController.Landing();
                _heroineController = null;
            }
            /*else if (Input.GetKey(KeyCode.S)) //Quick Fall unused in current build
            {
                _heroineController.Falling();
                _heroineController = null;
            }*/
            else if (Input.GetKey(KeyCode.Space) && timer >= _heroineController.diveTime)
            {
                _heroineController.Diving();
                _heroineController = null;
            }
        }
    }
}
