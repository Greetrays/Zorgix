using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction Dying;
    public event UnityAction ChangeHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Meteor meteor))
        {
            _currentHealth -= meteor.Damage;
            ChangeHealth?.Invoke();

            if (_currentHealth <= 0)
            {
                Dying?.Invoke();
            }
        }
    }
}
