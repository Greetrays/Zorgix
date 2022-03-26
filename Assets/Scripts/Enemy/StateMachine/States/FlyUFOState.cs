using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FlyUFOState : State
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(UFOAnimatorController.State.Fly);
        transform.parent = null;
    }
}
