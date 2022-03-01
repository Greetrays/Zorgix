using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeObject : MonoBehaviour
{
    [SerializeField] private float _chance;

    public float Chance => _chance;
}
