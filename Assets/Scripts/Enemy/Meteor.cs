using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private ParticleSystem _fragments;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            gameObject.SetActive(false);
            playerHealth.TakeDamage(Damage);
            Instantiate(_fragments, transform.position, Quaternion.identity);

            if (collision.TryGetComponent(out PlayerArmor playerArmor))
            {
                playerArmor.TakeDamage(Damage);
            }
        }
    }
}
