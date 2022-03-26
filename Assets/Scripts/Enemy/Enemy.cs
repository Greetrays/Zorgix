using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerHealth _target;

    public PlayerHealth Target => _target;

    public void SetTarget(PlayerHealth target)
    {
        _target = target;
    }
}
