using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private float _delay;
    [SerializeField] private float _minSpawnPoint;
    [SerializeField] private float _maxSpawnPoint;

    private float _elepsedTime;

    private void Start()
    {
        Init(_templates);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            if (TryGetObject(out GameObject obj))
            {
                Spawn(obj);
            }

            _elepsedTime = 0;
        }
    }

    private void Spawn(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = new Vector2(Container.position.x, Container.position.y + Random.Range(_minSpawnPoint, _maxSpawnPoint));
        DisableObject();
    }
}
