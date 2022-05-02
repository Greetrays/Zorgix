using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] protected UnityEvent _refilled;
    [SerializeField] protected UnityEvent _decreasing;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] private int _maxValue;

    public int CurrentValue { get; protected set; }

    public event UnityAction ChangeValue;

    public int MaxStats
    {
        get
        {
            return _maxValue;
        }
        protected set
        {
            _maxValue = MaxStats;
        }
    }

    protected void Change(int value)
    {
        CurrentValue += value;
        CurrentValue = Mathf.Clamp(CurrentValue, 0, MaxStats);
        ChangeValue?.Invoke();
    }

    protected void Refill()
    {
        _refilled?.Invoke();
        _particle.Play();
    }

    protected void Decreasing()
    {
        _decreasing?.Invoke();
    }
}
