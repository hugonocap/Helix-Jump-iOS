using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount; // the number of levels in the tower
    [SerializeField] private float _additionalScale; // additional scale to add to each platform on top of their original scale
    [SerializeField] private GameObject _beam; // the beam object to use as the base of the tower
    [SerializeField] private SpawnPlatform _spawnPlatform; // the platform to use as the spawn platform
    [SerializeField] private Platform[] _platform; // an array of platforms to use for the middle levels of the tower
    [SerializeField] private FinishPlatform _finishPlatform; // the platform to use as the finish platform

    private float _startAndFinishAdditionalScale = 0.5f; // additional scale to add to the start and finish platforms
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f; // the scale to set the beam on the y axis

    private void Awake()
    {
        Build(); // build the tower
    }

    private void Build()
    {
        // create the beam object and set its scale
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        // set the spawn position for the first platform
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        // spawn the spawn platform
        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        // spawn the middle levels of the tower
        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }

        // spawn the finish platform
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        // spawn the platform and set its rotation and parent
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        // update the spawn position for the next platform
        spawnPosition.y -= 1;
    }
}
