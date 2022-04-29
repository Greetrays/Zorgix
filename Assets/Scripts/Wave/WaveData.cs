using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Create new level", order = 51)]

public class WaveData : ScriptableObject
{
    [SerializeField] private List<SpawnObjectData> _templatesEnemys;
    [SerializeField] private List<SpawnObjectData> _templatesUpgradeObjects;
    [SerializeField] private float _duration;
    [SerializeField] private float _delayBetweenSpawnUpgradeObjects;
    [SerializeField] private float _delayBetweenSpawnEnemy;

    public float Duration => _duration;
    public List<SpawnObjectData> TemplatesEnemys => _templatesEnemys;
    public List<SpawnObjectData> TemplatesUpgradeObjects => _templatesUpgradeObjects;
    public float DelayBetweenSpawnUpgradeObjects => _delayBetweenSpawnUpgradeObjects;
    public float DelayBetweenSpawnEnemy => _delayBetweenSpawnEnemy;
}
