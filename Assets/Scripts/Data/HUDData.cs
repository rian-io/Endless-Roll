using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "HUD_Data", menuName = "Scriptable Objects/UI/HUD Data")]
public class HUDData : ScriptableObject
{
    public float levelAngle = 0;

    public float levelDistance = 0;

    private void Awake()
    {
        levelAngle = 0.0f;
    }

    public void setLevelAngle(float levelAngle)
    {
        this.levelAngle = levelAngle;
    }

    public string getLevelAngle()
    {
        return levelAngle.ToString("0.0");
    }
}
