using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstaclesList;

    [SerializeField] private int _doubleObstacleChance;

    [SerializeField] private float _obstacleSpawnStep = 5f;

    public void Spawn(float spawnPoint, float endPoint)
    {
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
        Obstacle obstacle = Instantiate(prefab, this.transform, false);
        float xPosisition = Random.Range(obstacle.GetNegativeXLimit(), obstacle.GetPositiveXLimit());

        obstacle.gameObject.transform.localPosition = new Vector3(xPosisition, 0f, spawnPoint);
    }
}
