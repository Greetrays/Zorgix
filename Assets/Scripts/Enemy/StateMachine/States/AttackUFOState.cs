using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackUFOState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _particle;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(UFOAnimatorController.State.Attack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth _player))
        {
            _player.TakeDamage(_damage);
            gameObject.SetActive(false);
            _particle.Play();

            if (collision.TryGetComponent(out PlayerArmor playerArmor))
            {
                playerArmor.TakeDamage(_damage);
            }
        }
    }
}
