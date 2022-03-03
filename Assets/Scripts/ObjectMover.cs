using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _minSpeedMove;
    [SerializeField] private float _maxSpeedMove;
    [SerializeField] private float _minDistanceShieldTrigger;
    [SerializeField] private ContactFilter2D _contactFilter2D;

    private float _speedMoveRight;
    private Rigidbody2D _rigidbody;
    private readonly RaycastHit2D[] _collisionObjects = new RaycastHit2D[1];
    private Vector3 _direction;
    private PlayerShield _player;

    private void OnEnable()
    {
        _direction = new Vector3(-1, 0, 0);
    }

    private void Start()
    {
        _speedMoveRight = Random.Range(_minSpeedMove, _maxSpeedMove);
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        transform.position += _direction * _speedMoveRight * Time.deltaTime;
        int countCollision = _rigidbody.Cast(Vector2.left, _contactFilter2D, _collisionObjects, _minDistanceShieldTrigger);

        if (_player.IsShield)
        {
            if (countCollision > 0)
            {
                if (_collisionObjects[0].transform.position.y < transform.position.y)
                {
                    _direction = new Vector3(-1, 0.5f, 0);
                }
                else if (_collisionObjects[0].transform.position.y >= transform.position.y)
                {
                    _direction = new Vector3(-1, -0.5f, 0);
                }
            }
        }
    }

    public void SetPlayer(PlayerShield player)
    {
        _player = player;
    }
}
