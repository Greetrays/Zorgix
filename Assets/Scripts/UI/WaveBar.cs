using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _numberWave;

    private void OnEnable()
    {
        _spawner.LaunchingNewWave += OnLaunchingNewWave;
    }

    private void OnDisable()
    {
        _spawner.LaunchingNewWave -= OnLaunchingNewWave;
    }

    private void OnLaunchingNewWave(float duration, int numberWave)
    {
        _slider.value = 0;
        _numberWave.text = numberWave.ToString();
        _slider.maxValue = duration;
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        float elepsedTime = 0;

        while(elepsedTime < _slider.maxValue)
        {
            elepsedTime += Time.deltaTime;
            _slider.value = elepsedTime;
            yield return null;
        }
    }
}
