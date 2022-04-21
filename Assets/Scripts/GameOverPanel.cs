using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private TMP_Text _playerMoney;
    [SerializeField] private float _delayBetweenShowPanel;
    [SerializeField] private TMP_Text _scorePerLevel;

    private CanvasGroup _panel;

    private void OnEnable()
    {
        _player.Dying += OnDying;
    }

    private void Start()
    {
        _panel = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        _player.Dying += OnDying;
    }

    public void OpenMenu()
    {
        Menu.Load();
    }

    public void RestartGame()
    {
        Game.Load();
    }
          
    private void OnDying()
    {
        StartCoroutine(ChangeTimeScale());
    }

    private void Open()
    {
        _panel.alpha = 1;
        _panel.blocksRaycasts = true;
        _panel.interactable = true;
        Time.timeScale = 0;
        _scorePerLevel.text = _playerMoney.text;
    }

    private IEnumerator ChangeTimeScale()
    {
        float _elepsedTimeDelay = 0;
        float _startValue = 1;
        float _endValue = 0;

        while (_elepsedTimeDelay < _delayBetweenShowPanel)
        {
            _elepsedTimeDelay += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.MoveTowards(_startValue, _endValue, _elepsedTimeDelay / _delayBetweenShowPanel);
            yield return null;
        }

        Open();
    }
}
