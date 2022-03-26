using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _spawner.LaunchingNewWave += OnLaunchingNewWave;
    }

    private void OnDisable()
    {
        _spawner.LaunchingNewWave -= OnLaunchingNewWave;
    }

    private void OnLaunchingNewWave(float duration)
    {
        _slider.value = 0;
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
