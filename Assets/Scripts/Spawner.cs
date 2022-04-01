using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spawner : Pool
{
    [Header("Спаунер")]
    [SerializeField] private float _minSpawnPoint;
    [SerializeField] private float _maxSpawnPoint;
    [SerializeField] private ObjectSpawner _objectSpawner;

    private List<SpawnObject> _templates;
    private float _elapsedTimeSpawn;
    private float _delay;

    [Header("Волны")]
    [SerializeField] private float _delayBeforeStartWave;
    [SerializeField] private Text _newWaveText;
    [SerializeField] private List<Wave> _waves;

    private float _elepsedTimeBeforStartWave;
    private float _elapsedWaveTime;
    private Wave _currentWave;
    private int _currentNumberWave;

    public event UnityAction<float, int> LaunchingNewWave;

    private void Start()
    {
        SetWave(_currentNumberWave);
        _templates = _currentWave.TemplatesEnemys;
        Init(_templates);
        _objectSpawner.InitSpawner(_currentWave.TemplatesUpgradeObjects, _currentWave.DelayBetweenSpawnUpgradeObjects);
        _delay = _currentWave.DelayBetweenSpawnEnemy;
        LaunchingNewWave?.Invoke(_currentWave.Duration, _currentNumberWave + 1);
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
                _elepsedTimeBeforStartWave += Time.deltaTime;

                if (_newWaveText.gameObject.activeSelf == false)
                {
                    _newWaveText.gameObject.SetActive(true);
                }

                if (_elepsedTimeBeforStartWave >= _delayBeforeStartWave)
                {
                    StartNextWave();
                    _elepsedTimeBeforStartWave = 0;
                    _newWaveText.gameObject.SetActive(false);
                }
            }
        }
    }

    public void NextWaveDevelopButton()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        TryDestroyObjects();
        _elapsedWaveTime = 0;
        SetWave(++_currentNumberWave);
        _templates = _currentWave.TemplatesEnemys;
        Init(_templates);
        _delay = _currentWave.DelayBetweenSpawnEnemy;
        _objectSpawner.InitSpawner(_currentWave.TemplatesUpgradeObjects, _currentWave.DelayBetweenSpawnUpgradeObjects);
        LaunchingNewWave?.Invoke(_currentWave.Duration, _currentNumberWave + 1);
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
        [SerializeField] private List<SpawnObject> _templatesEnemys;
        [SerializeField] private List<SpawnObject> _templatesUpgradeObjects;
        [SerializeField] private float _duration;
        [SerializeField] private float _delayBetweenSpawnUpgradeObjects;
        [SerializeField] private float _delayBetweenSpawnEnemy;

        public float Duration => _duration;
        public List<SpawnObject> TemplatesEnemys => _templatesEnemys;
        public List<SpawnObject> TemplatesUpgradeObjects => _templatesUpgradeObjects;
        public float DelayBetweenSpawnUpgradeObjects => _delayBetweenSpawnUpgradeObjects;
        public float DelayBetweenSpawnEnemy => _delayBetweenSpawnEnemy;
    }
}
