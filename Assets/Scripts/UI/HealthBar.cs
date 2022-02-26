using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Slider _bar;

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
    }

    private void OnChangeHealth()
    {
        _bar.value = _player.CurrentHealth;
    }
}
