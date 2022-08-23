using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishPlatform : Platform
{
    public event UnityAction FinishGame;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ball ball))
        {
            FinishGame?.Invoke();
        }
    }
}
