using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTransition : Transition
{
    private Vector3 _minDisablePoint;
    private Vector3 _maxDisablePoint;

    private void Start()
    {
        _minDisablePoint = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, -0.2f));
        _maxDisablePoint = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 1.2f));
    }

    private void Update()
    {
        if (transform.position.x > _maxDisablePoint.x ||
            transform.position.x < _minDisablePoint.x ||
            transform.position.y > _maxDisablePoint.y ||
            transform.position.y < _minDisablePoint.y)
        {
            NeedTransit = true;
        }
    }
}
