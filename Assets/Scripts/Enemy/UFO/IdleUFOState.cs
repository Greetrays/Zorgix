using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IdleUFOState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private List<UFODrone> _downgradeObjects;

    private Animator _animator;
    private float _elepsedTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(UFOAnimatorController.State.Idle);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            SpawnObject();
            _elepsedTime = 0;
        }
    }

    private void SpawnObject()
    {
        var newObject = Instantiate(_downgradeObjects[Random.Range(0, _downgradeObjects.Count)], transform.position, Quaternion.identity);

        if (newObject.TryGetComponent(out Enemy enemy))
        {
            enemy.SetTarget(Target);
        }
    }
}
