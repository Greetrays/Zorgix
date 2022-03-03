using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : UpgradeObject
{
    [SerializeField] private int _countHealth;

    public int CountHealth => _countHealth;
}
