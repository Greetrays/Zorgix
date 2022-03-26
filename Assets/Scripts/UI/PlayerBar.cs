using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speedChange;

    private Coroutine _change;

    private void OnEnable()
    {
        _player.ChangeStats += OnChange;
    }

    private void OnDisable()
    {
        _player.ChangeStats -= OnChange;
    }

    private void Start()
    {
        _bar.maxValue = _player.MaxStats;
        _bar.value = _player.MaxStats;
        _change = null;
    }

    private void OnChange()
    {
        if (_change != null)
        {
            StopCoroutine(_change);
        }

        _change = StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        while(_bar.value != _player.CurrentStats)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _player.CurrentStats, _speedChange * Time.deltaTime);

            yield return null;
        }

        _change = null;
    }
}
