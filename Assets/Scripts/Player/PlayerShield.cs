using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : TemporaryPlayerUpgrade
{
    public bool IsShield { get; private set; }

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
        if (collision.TryGetComponent(out Shield shield))
        {
            StartCoroutine(ChangeTime());
            IsShield = true;
        }
    }

    private void OnDisactivated()
    {
        IsShield = false;
    }
}
