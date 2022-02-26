using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        Vector3 newPosition = _camera.ViewportToWorldPoint(Input.mousePosition);

        gameObject.transform.position = newPosition;
    }
}
