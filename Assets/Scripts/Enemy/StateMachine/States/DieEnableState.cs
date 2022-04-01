using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnableState : State
{
    private void OnEnable()
    {
        gameObject.SetActive(false);
    }
}
