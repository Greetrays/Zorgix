using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class TemporaryPlayerUpgrade : MonoBehaviour
{
    [SerializeField] private UnityEvent _activated;
    [SerializeField] private UnityEvent _disactivated;
    [SerializeField] private ParticleSystem _particle;

    private float _timeAction;
    private float _elepsedTime;
    private Coroutine _changeTime;

    public event UnityAction Activated
    {
        add => _activated.AddListener(value);
        remove => _activated.RemoveListener(value);
    }

    public event UnityAction Disactivated
    {
        add => _disactivated.AddListener(value);
        remove => _disactivated.RemoveListener(value);
    }

    public float ElepsedTime => _elepsedTime;
    public float TimeAction => _timeAction;

    private void Start()
    {
        _changeTime = null;
    }

    protected void StartChangeTime(float timeAction)
    {
        if (_changeTime != null)
        {
            StopCoroutine(_changeTime);
        }

        _timeAction = timeAction;
        _changeTime = StartCoroutine(ChangeTime());
    }

    private IEnumerator ChangeTime()
    {
        _elepsedTime = _timeAction;
        _particle.Play();
        _activated?.Invoke();

        while (_elepsedTime > 0)
        {
            _elepsedTime -= Time.deltaTime;
            yield return null;
        }

        _changeTime = null;
        _particle.Stop();
        _disactivated?.Invoke();
    }
}
