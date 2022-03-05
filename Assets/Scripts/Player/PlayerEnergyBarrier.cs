﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergyBarrier : TemporaryPlayerUpgrade
{
    public bool IsEnergyBarrier { get; private set; }

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
            StartCoroutine(ChangeTime());
            IsEnergyBarrier = true;
        }
    }

    private void OnDisactivated()
    {
        IsEnergyBarrier = false;
    }
}