using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private PlayerHealth _target;

    public PlayerHealth Target => _target;
    public int Damage => _damage;

    public void SetTarget(PlayerHealth target)
    {
        _target = target;
    }
}
