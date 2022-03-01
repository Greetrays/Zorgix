using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Pool
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private float _minSpawnPoint;
    [SerializeField] private float _maxSpawnPoint;
    [SerializeField] private float _delay;

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
            if (TryGetObject(out GameObject gameObj))
            {
                TrySpawn(gameObj);
            }

            _elepsedTime = 0;
        }
    }

    private float GenerateChance()
    {
        return Random.Range(0.0f, 1.0f);
    }

    private void TrySpawn(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out UpgradeObject obj))
        {
            if (GenerateChance() <= obj.Chance)
            {
                gameObject.SetActive(true);
                gameObject.transform.position = new Vector2(Container.position.x, Random.Range(_minSpawnPoint, _minSpawnPoint));
            }
        }

        DisableObject();
    }
}
