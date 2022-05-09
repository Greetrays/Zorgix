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
            Change(armore.Count);
        }
    }
}
