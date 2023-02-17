using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : Platform // this script is a subclass of the Platform class
{
    [SerializeField] private Ball _ball; // the ball to spawn
    [SerializeField] private Transform _spawnPoint; // the position to spawn the ball at

    private void Awake()
    {
        Instantiate(_ball, _spawnPoint.position, Quaternion.identity); // spawn the ball at the spawn point
    }
}

