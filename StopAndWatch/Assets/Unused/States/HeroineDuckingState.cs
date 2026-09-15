using UnityEngine;

public class HeroineDuckingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _heroineController.heroine.localScale = new Vector3(1, 0.75f, 1);
        _heroineController.currentSpeed = _heroineController.duckingSpeed;
    }

    void Update()
    {
        if (_heroineController)
        {
            if (!Input.GetKey(KeyCode.S))
            {
                _heroineController.Standing();
                _heroineController = null;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                _heroineController.Jumping();
                _heroineController = null;
            }
        }
    }
}

