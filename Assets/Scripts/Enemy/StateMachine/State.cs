using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected PlayerHealth Target;

    public void Enter(PlayerHealth target)
    {
        if (enabled == false)
        {
            if (Target == null)
                Target = target;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public State GetNext()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            enabled = false;

            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }
    }
}