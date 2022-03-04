using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class BuffPanel : MonoBehaviour
{
    [SerializeField] private TemporaryPlayerUpgrade _player;

    private Image _panel;

    private void OnEnable()
    {
        _player.Activated += OnActivated;
        _panel = GetComponent<Image>();
    }

    private void OnDisable()
    {
        _player.Activated -= OnActivated;
    }

    private void Start()
    {
        _panel.fillAmount = 0;
    }

    private void OnActivated()
    {
        StartCoroutine(ChangeAmountFilled());
    }

    private IEnumerator ChangeAmountFilled()
    {
        _panel.fillAmount = 1;

        while (_panel.fillAmount > 0)
        {
            _panel.fillAmount = _player.ElepsedTime / _player.TimeAction;
            yield return null;
        }
    }
}
