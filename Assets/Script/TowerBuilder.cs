using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(5  ,_levelCount / 2f, 5);
    }
}
