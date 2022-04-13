using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FlyUFOState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        transform.parent = null;
    }

    private void OnEnable()
    {
        _animator.Play(UFOAnimatorController.State.Fly);
    }
}
