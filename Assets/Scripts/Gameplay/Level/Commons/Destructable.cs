using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    private GameObject _player;

    private float _referenceZDistance = 5f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(TagSystem.PLAYER);
    }

    private void Update()
    {
        if (transform.position.z <= _player.transform.position.z - _referenceZDistance)
        {
            Destroy(gameObject);
        }
    }
}
