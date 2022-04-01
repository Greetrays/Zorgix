using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerShield))]
[RequireComponent(typeof(PlayerArmor))]

public class PlayerHealth : PlayerStats
{
    private PlayerShield _playerShield;
    private PlayerArmor _playerArmor;

    public event UnityAction Dying;

    public bool IsShieldActive { get; private set; }

    private void OnValidate()
    {
        if (MaxStats <= 0)
        {
            MaxStats = 25;
        }
    }

    private void Start()
    {
        CurrentStats = MaxStats;
        _playerShield = GetComponent<PlayerShield>();
        _playerArmor = GetComponent<PlayerArmor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medicine medicine))
        {
            if (CurrentStats + medicine.CountHealth > MaxStats)
            {
                int newValueStats = MaxStats - CurrentStats;
                Change(newValueStats);
            }
            else if (CurrentStats + medicine.CountHealth <= MaxStats)
            {
                Change(medicine.CountHealth);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerShield.IsShield == false)
        {
            int fullPercantage = 100;
            int newDamage = damage * (fullPercantage - _playerArmor.CurrentStats) / fullPercantage;

            if (CurrentStats - newDamage > 0)
            {
                Change(-newDamage);
            }
            else
            {
                newDamage = CurrentStats;
                Change(-newDamage);
            }

            if (CurrentStats <= 0)
            {
                Dying?.Invoke();
            }
        }
    }
}
