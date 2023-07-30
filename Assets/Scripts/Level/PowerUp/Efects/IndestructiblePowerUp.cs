using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructiblePowerUp : PowerUp
{
    private Player _playerScript;

    private void Start()
    {
        _playerScript = FindObjectOfType<Player>();
    }

    public override void ChangeMaterial(Material emphasisMaterial, float duration)
    {
        _playerScript.ChangeMaterial(emphasisMaterial, duration);
    }

    public override void Apply()
    {
        _playerScript.TurnIndestructible(_duration);
    }
}
