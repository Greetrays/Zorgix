using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speedChange;
    [SerializeField] private TMP_Text _countText;

    private Coroutine _change;

    private void OnEnable()
    {
        _player.ChangeValue += OnChange;
    }

    private void OnDisable()
    {
        _player.ChangeValue -= OnChange;
    }

    private void Start()
    {
        _bar.maxValue = _player.MaxStats;
        _bar.value = _player.MaxStats;
        _countText.text = _player.MaxStats.ToString();
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
        while(_bar.value != _player.CurrentValue)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _player.CurrentValue, _speedChange * Time.deltaTime);
            _countText.text = System.Convert.ToInt32(_bar.value).ToString();

            yield return null;
        }

        _change = null;
    }
}
