using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [Header("Environment")]
    [SerializeField] private GameObject _environment;

    [SerializeField] private float _environmentReplaceStep = 150f;

    [SerializeField] private float _environmentLength = 300f;

    [SerializeField] private float _enviromentZPosition = 0f;

    [Header("Spawners")]
    [SerializeField] private ObstacleSpawner _obstacleSpawner;

    [SerializeField] private PowerUpSpawner _powerUpSpawner;

    private void Start()
    {
        _enviromentZPosition = _environment.transform.position.z;

        _obstacleSpawner.Spawn(_enviromentZPosition, _environmentLength);
        _powerUpSpawner.SpawnFirst(_environmentLength);
    }

    private void OnEnable()
    {
        ReplaceNotifier.OnSpawnerActivate += ReplaceEnvironmentHandler;
    }

    private void OnDisable()
    {
        ReplaceNotifier.OnSpawnerActivate -= ReplaceEnvironmentHandler;
    }

    private void ReplaceEnvironmentHandler()
    {
        _enviromentZPosition = _environment.transform.localPosition.z + _environmentReplaceStep;
        _environment.transform.localPosition = new Vector3(0f, 0, _enviromentZPosition);

        float startPoint = _enviromentZPosition + _environmentReplaceStep;
        float endPoint = startPoint + _environmentReplaceStep;

        _obstacleSpawner.Spawn(startPoint, endPoint);
        _powerUpSpawner.Spawn(startPoint, endPoint);
    }
}
