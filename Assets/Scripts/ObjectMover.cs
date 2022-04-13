using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _minSpeedMove;
    [SerializeField] private float _maxSpeedMove;
    [SerializeField] private float _minDistanceShieldTrigger;
    [SerializeField] private ContactFilter2D _contactFilter2D;
    [SerializeField] private Vector3 _startDirection;

    private float _speedMove;
    private Vector3 _direction ;
    private Rigidbody2D _rigidbody;
    private PlayerEnergyBarrier _player;
    private readonly RaycastHit2D[] _collisionObjects = new RaycastHit2D[1];  

    private void OnEnable()
    {
        _direction = _startDirection;
    }

    private void Start()
    {
        _speedMove = Random.Range(_minSpeedMove, _maxSpeedMove);
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        transform.position += _direction * _speedMove * Time.deltaTime;
        int countCollision = _rigidbody.Cast(Vector2.left, _contactFilter2D, _collisionObjects, _minDistanceShieldTrigger);

        if (_player.IsEnergyBarrier)
        {
            if (countCollision > 0)
            {
                float offsetMoveY = 0.5f;

                if (_collisionObjects[0].transform.position.y < transform.position.y)
                {
                    _direction = new Vector3(_direction.x, offsetMoveY, 0);
                }
                else if (_collisionObjects[0].transform.position.y >= transform.position.y)
                {
                    _direction = new Vector3(_direction.x, -offsetMoveY, 0);
                }
            }
        }
    }

    public void SetPlayer(PlayerEnergyBarrier player)
    {
        _player = player;
    }
}
