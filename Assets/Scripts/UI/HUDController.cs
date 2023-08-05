using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static event Action<bool> OnPauseAction;

    [SerializeField] private TMP_Text angleText;

    [SerializeField] private TMP_Text distanceText;

    private bool _isPaused;

    private void Awake()
    {
        _isPaused = false;
    }

    private void OnEnable()
    {
        HUDData.OnUpdateLevelAngle += UpdateLevelAngle;
        HUDData.OnUpdateLevelDistance += UpdateLevelDistance;
    }

    private void OnDisable()
    {
        HUDData.OnUpdateLevelAngle -= UpdateLevelAngle;
        HUDData.OnUpdateLevelDistance -= UpdateLevelDistance;
    }

    public void OnPause()
    {
        _isPaused = !_isPaused;
        OnPauseAction?.Invoke(_isPaused);
    }

    private void UpdateLevelAngle(float angle)
    {
        angleText.text = ConvertFloatToString(angle);
    }

    private void UpdateLevelDistance(float distance)
    {
        distanceText.text = ConvertFloatToString(distance);
    }

    private string ConvertFloatToString(float value)
    {
        return value.ToString("0.0");
    }
}
