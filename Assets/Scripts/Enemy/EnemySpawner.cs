using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : Pool
{
    [Header("Спаунер")]
    [SerializeField] private float _delay;
    [SerializeField] private float _minSpawnPoint;
    [SerializeField] private float _maxSpawnPoint;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private int _capacityPool;

    private List<GameObject> _templates;
    private float _elapsedTimeSpawn;

    [Header("Волны")]
    [SerializeField] private List<Wave> _waves;

    private float _elapsedWaveTime;
    private Wave _currentWave;
    private int _currentNumberWave;

    private void OnEnable()
    {
        _nextWaveButton.onClick.AddListener(TryStartNextWave);
    }

    private void Start()
    {
        SetWave(_currentNumberWave);
        _templates = _currentWave.Templates;
        Init(_templates, _capacityPool);
    }

    private void Update()
    {
        _elapsedTimeSpawn += Time.deltaTime;
        _elapsedWaveTime += Time.deltaTime;

        if (_elapsedWaveTime < _currentWave.Duration)
        {
            if (_elapsedTimeSpawn >= _delay)
            {
                if (TryGetObject(out GameObject obj))
                {
                    Spawn(obj);
                }

                _elapsedTimeSpawn = 0;
            }
        }
        else
        {
            if (_waves.Count > _currentNumberWave + 1)
            {
               _nextWaveButton.gameObject.SetActive(true);
            }
        }
    }

    private void TryStartNextWave()
    {
        _elapsedWaveTime = 0;
        _nextWaveButton.gameObject.SetActive(false);
        SetWave(++_currentNumberWave);
        _templates = _currentWave.Templates;
        Init(_templates, _capacityPool);      
    }

    private void Spawn(GameObject obj)
    {
        float randomY = Random.Range(_minSpawnPoint, _maxSpawnPoint);

        obj.SetActive(true);
        obj.transform.position = new Vector2(Container.position.x, Container.position.y + randomY);
        DisableObject();
    }

    private void SetWave(int numberWave)
    {
        _currentWave = _waves[numberWave];
    }

    [System.Serializable]
    public class Wave
    {
        [SerializeField] private List<GameObject> _templates;
        [SerializeField] private float _duration;
        [SerializeField] private AudioClip _sound;

        public float Duration => _duration;
        public List<GameObject> Templates => _templates;
    }
}
