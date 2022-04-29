using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerShield))]
[RequireComponent(typeof(PlayerArmor))]

public class PlayerHealth : PlayerStats
{
    [SerializeField] private ParticleSystem _diedParticle;

    private PlayerShield _playerShield;
    private PlayerArmor _playerArmor;
    private UnityEvent _died;

    public event UnityAction Died;

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
        CurrentValue = MaxStats;
        _playerShield = GetComponent<PlayerShield>();
        _playerArmor = GetComponent<PlayerArmor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medicine medicine))
        {
            Refill();

            if (CurrentValue + medicine.Count > MaxStats)
            {
                int newValueStats = MaxStats - CurrentValue;
                Change(newValueStats);
            }
            else if (CurrentValue + medicine.Count <= MaxStats)
            {
                Change(medicine.Count);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerShield.IsShield == false)
        {
            int fullPercantage = 100;
            int newDamage = damage * (fullPercantage - _playerArmor.CurrentValue) / fullPercantage;
            
            Decreasing();

            if (CurrentValue - newDamage > 0)
            {
                Change(-newDamage);
            }
            else
            {
                newDamage = CurrentValue;
                Change(-newDamage);
            }

            if (CurrentValue <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Died?.Invoke();
        Instantiate(_diedParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
