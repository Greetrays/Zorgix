using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected PlayerHealth Target;

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(PlayerHealth player)
    {
        Target = player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
