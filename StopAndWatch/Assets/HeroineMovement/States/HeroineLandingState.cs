using UnityEngine;
using System.Collections.Generic;

public class HeroineLandingState : MonoBehaviour, IHeroineState
{
    private HeroineController _heroineController;
    float timer;

    public void Handle(HeroineController heroineController)
    {
        if (!_heroineController)
            _heroineController = heroineController;
        _heroineController.heroine.localScale = new Vector3(1, 0.5f, 1);
        timer = 0;
    }

    void Update()
    {
        if (_heroineController)
        {
            Debug.Log("Landed");
            timer += Time.deltaTime;
            if(timer > _heroineController.landingTime)
            {
                _heroineController.Standing();
                _heroineController = null;
            }
        }
    }
}

