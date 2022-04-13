using UnityEngine;

public class FlyState : State
{
    [SerializeField] private float _speed;

    private Vector3 _duration;

    private void Start()
    {
        _duration = Target.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position += _duration * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth player))
        {
            Destroy(gameObject);
        }
    }
}
