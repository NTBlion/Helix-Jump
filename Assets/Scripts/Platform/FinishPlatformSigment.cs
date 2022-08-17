using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishPlatformSigment : MonoBehaviour
{
    public event UnityAction OnFinishGame;

    public void OnTriggerEnter(Collider other)
    {
        OnFinishGame?.Invoke();
    }
}
