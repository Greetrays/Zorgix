using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : TemporaryPlayerUpgrade
{
    [SerializeField] private GameObject _shieldSprite;
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
            StartChangeTime();
            _shieldSprite.SetActive(true);
            IsShield = true;
        }
    }

    private void OnDisactivated()
    {
        _shieldSprite.SetActive(false);
        IsShield = false;
    }
}
