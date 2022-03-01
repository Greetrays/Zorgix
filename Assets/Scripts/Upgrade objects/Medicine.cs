using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : UpgradeObject
{
    [SerializeField] private int _countHealth;

    public int CountHealth => _countHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth player))
        {
            gameObject.SetActive(false);
        }
    }
}
