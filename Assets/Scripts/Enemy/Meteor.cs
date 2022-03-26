using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _fragments;

    public int Damage => _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            gameObject.SetActive(false);
            playerHealth.TakeDamage(_damage);
            Instantiate(_fragments, transform.position, Quaternion.identity);

            if (collision.TryGetComponent(out PlayerArmor playerArmor))
            {
                playerArmor.TakeDamage(_damage);
            }
        }
    }
}
