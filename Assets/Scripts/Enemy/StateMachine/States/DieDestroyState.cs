using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDestroyState : State
{
    private void OnEnable()
    {
        Destroy(gameObject);
    }
}
