using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text angleText;

    [SerializeField] TMP_Text distanceText;

    private void OnEnable()
    {
        HUDData.OnUpdateLevelAngle += updateLevelAngle;
        HUDData.OnUpdateLevelDistance += updateLevelDistance;
    }

    private void OnDisable()
    {
        HUDData.OnUpdateLevelAngle -= updateLevelAngle;
        HUDData.OnUpdateLevelDistance -= updateLevelDistance;
    }

    private void updateLevelAngle(float angle)
    {
        angleText.text = convertFloatToString(angle);
    }

    private void updateLevelDistance(float distance)
    {
        distanceText.text = convertFloatToString(distance);
    }

    private string convertFloatToString(float value)
    {
        return value.ToString("0.0");
    }
}
