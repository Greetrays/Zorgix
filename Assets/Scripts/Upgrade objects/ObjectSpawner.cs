using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Pool
{
    [SerializeField] private float _minSpawnPoint;
    [SerializeField] private float _maxSpawnPoint;

    private float _delay;
    private float _elepsedTime;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            if (TryGetRandomObject(out GameObject gameObj))
            {
                TrySpawn(gameObj);
            }
          
            DisableObject();
            _elepsedTime = 0;
        }
    }

    public void InitSpawner(List<SpawnObjectData> templates, float delay)
    {
        TryDestroyObjects();
        Init(templates);
        _delay = delay;
    }

    private void TrySpawn(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector2(Container.position.x, Random.Range(_minSpawnPoint, _maxSpawnPoint));
    }
}
