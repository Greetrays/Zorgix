using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class UFODrone : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            gameObject.SetActive(false);
            playerHealth.TakeDamage(Damage);

            if (collision.TryGetComponent(out PlayerArmor playerArmor))
            {
                playerArmor.TakeDamage(Damage);
            }
        }
    }
}
