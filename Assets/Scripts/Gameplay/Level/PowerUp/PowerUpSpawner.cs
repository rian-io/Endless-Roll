using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<PowerUp> _powerUpsList;

    [SerializeField] private float _powerUpInitialPosition = 52.5f;

    [SerializeField] private float _powerUpSpawnStep = 100f;

    [ThreadStatic] private static System.Random _local;

    public void SpawnFirst(float endPoint)
    {
        Spawn(0, endPoint);
    }

    public void Spawn(float startPoint, float endPoint)
    {
        startPoint += _powerUpInitialPosition;
        //endPoint -= _powerUpInitialPosition;

        while (startPoint <= endPoint)
        {
            _powerUpsList.Shuffle();

            float xPosition = -2f;

            foreach (var prefab in _powerUpsList)
            {
                PowerUp powerUp = Instantiate(prefab, this.transform, false);
                powerUp.gameObject.transform.localPosition = new Vector3(xPosition, 0f, startPoint);

                xPosition += 2f;
            }

            startPoint += _powerUpSpawnStep;
        }
    }
}
