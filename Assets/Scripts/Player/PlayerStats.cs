using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] private UnityEvent _changeStats;
    [SerializeField] private int _maxStats;

    public int MaxStats
    {
        get
        {
            return _maxStats;
        }
        protected set
        {
            _maxStats = MaxStats;
        }
    }
    public int CurrentStats { get; protected set; }

    public event UnityAction ChangeStats
    {
        add => _changeStats.AddListener(value);
        remove => _changeStats.RemoveListener(value);
    }

    protected void Change(int value)
    {
        CurrentStats += value;
        _changeStats?.Invoke();
    }
}
