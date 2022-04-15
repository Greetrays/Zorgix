using UnityEngine;

public class Armor : UpgradeObject
{
    [Header("Характеристики брони")]
    [SerializeField] private int _currentCount;
    [SerializeField] private int _boostCount;

    public int Count => _currentCount;

    protected override void Upgrade()
    {
        _currentCount += _boostCount;
    }
}
