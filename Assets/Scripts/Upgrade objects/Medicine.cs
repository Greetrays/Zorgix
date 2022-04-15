using UnityEngine;

public class Medicine : UpgradeObject
{
    [Header("Характеристики аптечки")]
    [SerializeField] private int _currentCount;
    [SerializeField] private int _boostCount;

    public int Count => _currentCount;

    protected override void Upgrade()
    {
        _currentCount += _boostCount;
    }
}
