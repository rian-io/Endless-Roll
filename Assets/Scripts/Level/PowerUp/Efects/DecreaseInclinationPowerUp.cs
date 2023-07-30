using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseInclinationPowerUp : GroundPowerUp
{
    [SerializeField]
    private float _decreaseAngles = 5f;

    public override void Apply()
    {
        _levelManager.DecreaseInclination(_decreaseAngles, _duration);
    }

    public override void ChangeMaterial(Material emphasisMaterial, float duration)
    {
        _ground.ChangeMaterial(emphasisMaterial, duration);
    }
}
