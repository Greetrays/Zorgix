using UnityEngine;

public class Armor : UpgradeObject
{
    [SerializeField] private int _count;

    public int Count => _count;
}
