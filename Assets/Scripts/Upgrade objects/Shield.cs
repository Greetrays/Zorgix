using UnityEngine;

public class Shield : UpgradeObject
{
    [Header("Характеристики щита")]
    [SerializeField] private float _timeAction;
    [SerializeField] private float _boostTime;

    public float TimeAction => _timeAction;

    protected override void Upgrade()
    {
        _timeAction += _boostTime;
    }
}
