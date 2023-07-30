using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PowerUpSpawner
{
    private float _powerUpSpawnStep = 100f;

    private GameObject _powerUpsContainer;

    private List<PowerUp> _powerUpsList;

    [ThreadStatic] private static System.Random _local;

    public PowerUpSpawner(GameObject powerUpsContainer, List<PowerUp> powerUpsList)
    {
        this._powerUpsContainer = powerUpsContainer;
        this._powerUpsList = powerUpsList;
    }

    public void Spawn(float startPoint, float endPoint)
    {
        while (startPoint <= endPoint)
        {
            shuffle();

            float xPosition = -2f;

            foreach (var prefab in _powerUpsList)
            {
                PowerUp powerUp = MonoBehaviour.Instantiate(prefab, _powerUpsContainer.transform, false);
                powerUp.gameObject.transform.localPosition = new Vector3(xPosition, 0f, startPoint);

                xPosition += 2f;
            }

            startPoint += _powerUpSpawnStep;
        }
    }

    private System.Random generateRandom()
    {
        return _local ?? (_local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
    }

    private void shuffle()
    {
        int n = _powerUpsList.Count;
        while (n > 1)
        {
            n--;
            int k = generateRandom().Next(n + 1);
            PowerUp value = _powerUpsList[k];
            _powerUpsList[k] = _powerUpsList[n];
            _powerUpsList[n] = value;
        }
    }

}
