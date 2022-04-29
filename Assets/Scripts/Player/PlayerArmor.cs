using UnityEngine;

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
        CurrentValue = MaxStats;
        _playerShield = GetComponent<PlayerShield>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Armor armore))
        {
            Refill();

            if (CurrentValue + armore.Count > MaxStats)
            {
                int newValueStats = MaxStats - CurrentValue;
                Change(newValueStats);
            }
            else if (CurrentValue + armore.Count <= MaxStats)
            {
                Change(armore.Count);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerShield.IsShield == false)
        {
            Decreasing();

            if (CurrentValue > 0)
            {
                Change(-damage);

                if (CurrentValue < 0)
                {
                    CurrentValue = 0;
                }
            }
        }
    }
}
