using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatformSigment : MonoBehaviour
{
    [SerializeField] private EndGameUI _endGameUI;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_endGameUI);
    }
}
