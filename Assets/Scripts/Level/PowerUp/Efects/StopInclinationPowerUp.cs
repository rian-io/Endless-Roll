using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopInclinationPowerUp : GroundPowerUp
{
    public override void Apply()
    {
        _levelManager.StopInclination(_duration);
    }

    public override void ChangeMaterial(Material emphasisMaterial, float duration)
    {
        _ground.ChangeMaterial(emphasisMaterial, duration);
    }
}
