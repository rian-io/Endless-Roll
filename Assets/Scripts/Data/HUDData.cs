using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "HUD_Data", menuName = "Scriptable Objects/UI/HUD Data")]
public class HUDData : ScriptableObject
{
    public static event Action<float> OnUpdateLevelAngle;

    public static event Action<float> OnUpdateLevelDistance;

    public void SetLevelAngle(float angle)
    {
        OnUpdateLevelAngle?.Invoke(angle);
    }

    public void SetLevelDistance(float distance)
    {
        OnUpdateLevelDistance?.Invoke(distance);
    }
}
