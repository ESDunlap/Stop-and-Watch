using UnityEngine;

public class HeroineDivingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _heroineController.dive = true;
        Debug.Log("Diving ");
    }

    void Update()
    {
        if (_heroineController)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, 1.5f) && _heroineController.rigidBody.linearVelocity.y <= 0.1f)
            {
                _heroineController.Landing();
                _heroineController = null;
            }
        }
    }
}

