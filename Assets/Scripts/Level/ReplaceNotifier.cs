using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceNotifier : MonoBehaviour
{
    public static event Action OnSpawnerActivate;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagSystem.PLAYER))
        {
            OnSpawnerActivate?.Invoke();
        }
    }
}
