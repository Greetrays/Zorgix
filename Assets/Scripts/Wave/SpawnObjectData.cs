using UnityEngine;

[System.Serializable]
public class SpawnObjectData
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _count;

    public GameObject Template => _template;
    public int Count => _count;
}
