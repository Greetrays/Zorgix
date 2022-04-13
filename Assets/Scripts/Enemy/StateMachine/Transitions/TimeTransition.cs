using UnityEngine;

public class TimeTransition : Transition
{
    [SerializeField] private float _duration;

    private float _elepsedTime;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _duration)
        {
            NeedTransit = true;
            _elepsedTime = 0;
        }
    }
}
