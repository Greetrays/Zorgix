using UnityEngine;

public class EnergyBarrier : UpgradeObject
{
    [Header("Характеристики барьера")]
    [SerializeField] private float _timeAction;
    [SerializeField] private float _boostTime;

    public float TimeAction => _timeAction;

    protected override void Upgrade()
    {
        _timeAction += _boostTime;
    }
}
