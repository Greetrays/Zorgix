using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private ParticleSystem _fragments;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
            player.TakeDamage(Damage);
            Instantiate(_fragments, transform.position, Quaternion.identity);
        }
    }
}
