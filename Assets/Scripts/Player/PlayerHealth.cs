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
    public bool IsShieldActive { get; private set; }

    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 25;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        IsShieldActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Meteor meteor))
        {
            Change(-meteor.Damage);

            if (_currentHealth <= 0)
            {
                Dying?.Invoke();
            }
        }
        else if (collision.TryGetComponent(out Medicine medicine))
        {
            if (_currentHealth + medicine.CountHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
                _changeHealth?.Invoke();
            }
            else if (_currentHealth + medicine.CountHealth <= _maxHealth)
            {
                Change(medicine.CountHealth);
            }
        }
    }

    private void Change(int health)
    {
        _currentHealth += health;
        _changeHealth?.Invoke();
    }
}
