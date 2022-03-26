using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DowngradeObject : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerHealth _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}
