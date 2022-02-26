using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _minDistanceX;
    [SerializeField] private float _maxDistanceX;
    [SerializeField] private float _minDistanceY;
    [SerializeField] private float _maxDistanceY;
    private void Update()
    {
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);          
        transform.position = Vector2.Lerp(transform.position, objPosition, _speedMove * Time.deltaTime);
        float correctPositionX = Mathf.Clamp(transform.position.x, _minDistanceX, _maxDistanceX);
        float correctPositionY = Mathf.Clamp(transform.position.y, _minDistanceY, _maxDistanceY);
        transform.position = new Vector2(correctPositionX, correctPositionY);
    }
}
