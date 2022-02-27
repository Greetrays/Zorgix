using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speedChange;

    private Coroutine _changeHealth;

    private void OnEnable()
    {
        _player.ChangeHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnChangeHealth;
    }

    private void Start()
    {
        _bar.maxValue = _player.MaxHealth;
        _bar.value = _player.MaxHealth;
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
        while(_bar.value > _player.CurrentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _player.CurrentHealth, _speedChange * Time.deltaTime);

            yield return null;
        }

        _changeHealth = null;
    }
}
