using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _finishUItemplate;

    private FinishPlatform _finishPlatform;

    private void Awake()
    {
        _finishPlatform = _levelGenerator.Build();
    }

    private void Start()
    {
        _finishPlatform.FinishGame += OnGameFinished;
    }


    private void OnDisable()
    {
        _finishPlatform.FinishGame -= OnGameFinished;
    }

    private void OnGameFinished()
    {
        Debug.Log("Я родился");
        Instantiate(_finishUItemplate);
    }
}
