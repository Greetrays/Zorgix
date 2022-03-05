using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TemporaryPlayerUpgrade : MonoBehaviour
{
    [SerializeField] private float _timeAction;
    [SerializeField] private UnityEvent _activated;
    [SerializeField] private UnityEvent _disactivated;

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

    protected void StartChangeTime()
    {
        if (_changeTime != null)
        {
            StopCoroutine(_changeTime);
        }

        _changeTime = StartCoroutine(ChangeTime());
    }

    private IEnumerator ChangeTime()
    {
        _elepsedTime = _timeAction;
        _activated?.Invoke();

        while (_elepsedTime > 0)
        {
            _elepsedTime -= Time.deltaTime;
            yield return null;
        }

        _changeTime = null;
        _disactivated?.Invoke();
    }
}
