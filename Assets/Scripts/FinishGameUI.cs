using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishGameUI : MonoBehaviour
{
    [SerializeField] private FinishPlatformSigment _finishPlatformSigment;
    [SerializeField] private GameObject _finishGameUItemplate;

    private void Awake()
    {
        _finishPlatformSigment.GetComponent<FinishPlatformSigment>();
    }

    private void OnEnable()
    {
        _finishPlatformSigment.OnFinishGame += FinishGame;
    }

    private void OnDisable()
    {
        _finishPlatformSigment.OnFinishGame -= FinishGame;
    }

    private void FinishGame()
    {
        Instantiate(_finishGameUItemplate.gameObject);
    }
}
