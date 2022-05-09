using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class UFODrone : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
            player.TakeDamage(Damage);
        }
    }
}
