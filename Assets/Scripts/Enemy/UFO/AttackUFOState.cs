using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UFO))]

public class AttackUFOState : State
{
    [SerializeField] private ParticleSystem _particle;

    private Animator _animator;
    private UFO _ufo;

    private void Awake()
    {
        _ufo = GetComponent<UFO>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(UFOAnimatorController.State.Attack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth _player))
        {
            _player.TakeDamage(_ufo.Damage);
            gameObject.SetActive(false);
            _particle.Play();

            if (collision.TryGetComponent(out PlayerArmor playerArmor))
            {
                playerArmor.TakeDamage(_ufo.Damage);
            }
        }
    }
}
