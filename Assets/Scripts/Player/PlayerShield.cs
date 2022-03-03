using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private float _timeAction;
    [SerializeField] private UnityEvent _activated;

    private float _elepsedTime;

    public event UnityAction Activated
    {
        add => _activated.AddListener(value);
        remove => _activated.RemoveListener(value);
    }

    public bool IsShield { get; private set; }
    public float ElepsedTime => _elepsedTime;
    public float TimeAction => _timeAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Shield shield))
        {
            IsShield = true;
            StartCoroutine(ChangeTime());
            _activated?.Invoke();
        }
    }

    private IEnumerator ChangeTime()
    {
        _elepsedTime = _timeAction;

        while (_elepsedTime > 0)
        {
            _elepsedTime -= Time.deltaTime;
            yield return null;
        }

        IsShield = false;
    }
}
