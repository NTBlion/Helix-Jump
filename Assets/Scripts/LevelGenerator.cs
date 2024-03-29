using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platform;

    private float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionScale / 2f;


    public  FinishPlatform Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }

        FinishPlatform finishPlatform = SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);

        return finishPlatform;
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }

    private FinishPlatform SpawnPlatform(FinishPlatform platform, ref Vector3 spawnPosition, Transform parent)
    {
           

        FinishPlatform finishPlatform = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;

        return finishPlatform;
    }

}
