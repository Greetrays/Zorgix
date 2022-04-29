using UnityEngine;

public class PlayerEnergyBarrier : TemporaryPlayerUpgrade
{
    public bool IsActive { get; private set; }

    private void OnEnable()
    {
        Disactivated += OnDisactivated;
    }

    private void OnDisable()
    {
        Disactivated -= OnDisactivated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnergyBarrier shield))
        {
            StartChangeTime(shield.TimeAction);
            IsActive = true;
        }
    }

    private void OnDisactivated()
    {
        IsActive = false;
    }
}
