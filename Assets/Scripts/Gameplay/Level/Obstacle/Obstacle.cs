using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _length;

    private readonly float _groudnWidth = 2.5f;

    public float GetPositiveXLimit()
    {
        return _groudnWidth - (_length / 2);
    }

    public float GetNegativeXLimit()
    {
        return -1 * _groudnWidth + (_length / 2);
    }
}
