using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    [SerializeField] private float _maxDistanceX;
    [SerializeField] private float _minDistanceY;
    [SerializeField] private float _maxDistanceY;

    private Vector3 newTargetPosition;
    private Vector3 oldPosition;
    private float _minDistanceX;

    private void Start()
    {
        float wigthSprite = gameObject.GetComponent<Renderer>().bounds.size.x;
        _minDistanceX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + wigthSprite / 2;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                newTargetPosition = mousePosition;
                oldPosition = transform.position;
            }
         
            transform.position = Vector2.Lerp(transform.position, oldPosition + mousePosition - newTargetPosition, _speedMove * Time.deltaTime); ;
            float correctPositionX = Mathf.Clamp(transform.position.x, _minDistanceX, _maxDistanceX);
            float correctPositionY = Mathf.Clamp(transform.position.y, _minDistanceY, _maxDistanceY);
            transform.position = new Vector2(correctPositionX, correctPositionY);
        }
    }
}
