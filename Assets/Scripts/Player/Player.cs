using UnityEngine;

[RequireComponent(typeof(PlayerArmor))]
[RequireComponent(typeof(PlayerShield))]
[RequireComponent(typeof(PlayerHealth))]

public class Player : MonoBehaviour
{
    private PlayerArmor _armor;
    private PlayerShield _shield;
    private PlayerHealth _health;

    private void Start()
    {
        _armor = GetComponent<PlayerArmor>();
        _shield = GetComponent<PlayerShield>();
        _health = GetComponent<PlayerHealth>();
    }

    public void TakeDamage(int damage)
    {
        if (_shield.IsShield == false)
        {
            _armor.TakeDamage(damage);

            int fullPercantage = 100;
            int newDamage = damage * (fullPercantage - _armor.CurrentValue) / fullPercantage;
            _health.TakeDamage(newDamage);
        }
    }
}
