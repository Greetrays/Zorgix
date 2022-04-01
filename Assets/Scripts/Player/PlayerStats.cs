using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] private UnityEvent _decreasing;
    [SerializeField] private UnityEvent _refilling;
    [SerializeField] private int _maxStats;
    [SerializeField] private ParticleSystem _particle;

    public int CurrentStats { get; protected set; }

    public event UnityAction ChangeStats;

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

    protected void Change(int value)
    {
        CurrentStats += value;
        ChangeStats?.Invoke();
        CheckValue(value);
    }
    
    private void CheckValue(int value)
    {
        if (value > 0)
        {
            _refilling?.Invoke();
            _particle.Play();
        }
        else
        {
            _decreasing?.Invoke();
        }
    }
}
