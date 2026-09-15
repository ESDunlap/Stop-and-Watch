using UnityEngine;

public class HeroineStateContext
{
    public IHeroineState CurrentState;
    private readonly HeroineController _heroineController;

    public HeroineStateContext(HeroineController heroineController)
    {
        _heroineController = heroineController;
    }

    public void Transition()
    {
        CurrentState.Handle(_heroineController);
    }

    public void Transition(IHeroineState state)
    {
        CurrentState = state;
        CurrentState.Handle(_heroineController);
    }
}
