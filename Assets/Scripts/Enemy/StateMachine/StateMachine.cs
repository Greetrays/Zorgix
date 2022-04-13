using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private PlayerHealth _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void OnEnable()
    {
        SetState(_firstState);
    }

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        SetState(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var next = _currentState.GetNext();

        if (next != null)
            SetState(next);
    }

    private void SetState(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}