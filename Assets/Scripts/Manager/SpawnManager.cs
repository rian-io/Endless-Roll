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

    [Header("Obstacles")]
    [SerializeField] private GameObject _obstaclesContainer;

    [SerializeField] private List<Obstacle> _obstaclesList;

    [SerializeField] private int _doubleObstacleChance;

    [SerializeField] private float _obstacleSpawnStep = 5f;

    [Header("Power Ups")]
    [SerializeField] private GameObject _powerUpsContainer;

    [SerializeField] private List<PowerUp> _powerUpsList;

    [SerializeField] private float _powerUpInitialPosition = 52.5f;

    [SerializeField] private float _powerUpSpawnStep = 100f;

    private PowerUpSpawner _powerUpSpawner;

    private ObstacleSpawner _obstacleSpawner;

    private void Start()
    {
        _powerUpSpawner = new PowerUpSpawner(_powerUpsContainer, _powerUpsList);

        _enviromentZPosition = _environment.transform.position.z;

        SpawnObstacles(0, true);

        _powerUpSpawner.Spawn(_powerUpInitialPosition, (_powerUpInitialPosition + _environmentLength - _powerUpSpawnStep));
    }

    private void OnEnable()
    {
        ReplaceNotifier.OnSpawnerActivate += ReplaceEnvironment;
    }

    private void OnDisable()
    {
        ReplaceNotifier.OnSpawnerActivate -= ReplaceEnvironment;
    }

    private void ReplaceEnvironment()
    {
        _enviromentZPosition = _environment.transform.localPosition.z + _environmentReplaceStep;
        _environment.transform.localPosition = new Vector3(0f, 0, _enviromentZPosition);

        SpawnObstacles(_enviromentZPosition + _environmentReplaceStep);
        SpawnPowerUps();
    }

    private void SpawnPowerUps()
    {
        float startPoint = getStartPointPowerUps();
        float endPoint = getEndPointPowerUps(startPoint);

        _powerUpSpawner.Spawn(startPoint, endPoint);
    }

    private float getStartPointObstacles()
    {
        return _enviromentZPosition + _environmentReplaceStep;
    }

    private float getEndPointObstacles(float startPoint)
    {
        return startPoint + _environmentReplaceStep;
    }

    private float getStartPointPowerUps()
    {
        return _enviromentZPosition + _environmentReplaceStep + _powerUpInitialPosition;
    }

    private float getEndPointPowerUps(float startPoint)
    {
        return startPoint + _environmentReplaceStep - _powerUpSpawnStep;
    }

    private void SpawnObstacles(float spawnPoint, bool first = false)
    {
        float endPoint = spawnPoint + (first ? _environmentLength : _environmentReplaceStep);

        while (spawnPoint <= endPoint)
        {
            int prefabIndex = Random.Range(0, 2);
            Obstacle prefab = _obstaclesList[prefabIndex];

            MakeInstance(prefab, spawnPoint);

            if (Random.Range(0, 101) <= _doubleObstacleChance)
            {
                prefabIndex = prefabIndex == 1 ? 0 : Random.Range(0, 2);
                prefab = _obstaclesList[prefabIndex];
                MakeInstance(prefab, spawnPoint);
            }

            spawnPoint += _obstacleSpawnStep;
        }
    }

    private void MakeInstance(Obstacle prefab, float spawnPoint)
    {
        Obstacle obstacle = Instantiate(prefab, _obstaclesContainer.transform, false);
        float xPosisition = Random.Range(obstacle.GetNegativeXLimit(), obstacle.GetPositiveXLimit());

        obstacle.gameObject.transform.localPosition = new Vector3(xPosisition, 0f, spawnPoint);
    }
}
