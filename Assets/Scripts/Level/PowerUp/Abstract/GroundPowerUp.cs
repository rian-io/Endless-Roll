using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundPowerUp : PowerUp
{
    protected LevelManager _levelManager;

    protected Ground _ground;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _ground = FindObjectOfType<Ground>();
    }
}
