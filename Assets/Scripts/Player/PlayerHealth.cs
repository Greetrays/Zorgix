using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _changeHealth;

    private int _currentHealth;


    public event UnityAction Dying;
    public event UnityAction ChangeHealth
    {
        add => _changeHealth.AddListener(value);
        remove => _changeHealth.RemoveListener(value);
    }

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Meteor meteor))
        {
            _currentHealth -= meteor.Damage;
            _changeHealth?.Invoke();

            if (_currentHealth <= 0)
            {
                Dying?.Invoke();
            }
        }
    }
}
