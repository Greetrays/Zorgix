using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speedChange;

    private Coroutine _changeHealth;

    private void OnEnable()
    {
        _player.ChangeStats += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangeStats -= OnChangeHealth;
    }

    private void Start()
    {
        _bar.maxValue = _player.MaxStats;
        _bar.value = _player.MaxStats;
        _changeHealth = null;
    }

    private void OnChangeHealth()
    {
        if (_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
        }

        _changeHealth = StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while(_bar.value != _player.CurrentStats)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _player.CurrentStats, _speedChange * Time.deltaTime);

            yield return null;
        }

        _changeHealth = null;
    }
}
