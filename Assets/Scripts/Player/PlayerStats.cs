using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] protected UnityEvent _refilling;
    [SerializeField] protected UnityEvent _decreasing;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] private int _maxStats;

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
    }

    protected void Refilling()
    {
        _refilling?.Invoke();
        _particle.Play();
    }

    protected void Decreasing()
    {
        _decreasing?.Invoke();
    }
}
