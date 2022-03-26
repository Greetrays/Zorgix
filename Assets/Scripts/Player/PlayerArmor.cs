using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerArmor : PlayerStats
{
    private PlayerShield _playerShield;
    public bool IsShieldActive { get; private set; }

    private void OnValidate()
    {
        if (MaxStats <= 0)
        {
            MaxStats = 25;
        }
        else if (MaxStats > 50)
        {
            MaxStats = 50;
        }
    }

    private void Start()
    {
        CurrentStats = MaxStats;
        _playerShield = GetComponent<PlayerShield>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Armor armore))
        {
            if (CurrentStats + armore.Count > MaxStats)
            {
                int newValueStats = MaxStats - CurrentStats;
                Change(newValueStats);
            }
            else if (CurrentStats + armore.Count <= MaxStats)
            {
                Change(armore.Count);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerShield.IsShield == false)
        {
            if (CurrentStats > 0)
            {
                Change(-damage);

                if (CurrentStats < 0)
                {
                    CurrentStats = 0;
                }
            }
        }
    }
}
