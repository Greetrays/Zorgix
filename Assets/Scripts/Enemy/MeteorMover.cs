using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    [SerializeField] private float _minSpeedMove;
    [SerializeField] private float _maxSpeedMove;

    private float _speed;

    private void Start()
    {
        _speed = Random.Range(_minSpeedMove, _maxSpeedMove);
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
