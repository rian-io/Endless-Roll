using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionReader : MonoBehaviour
{
    [Header("HUD Data")]
    [SerializeField] HUDData hudData;

    private void Update()
    {
        float distance = ConvertToMeters(GetDistance());
        hudData.SetLevelDistance(distance);
    }

    private float GetDistance()
    {
        float a = transform.localPosition.z;
        float b = transform.localPosition.y;

        return (Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2)));
    }

    private float ConvertToMeters(float distance)
    {
        return distance / 10;
    }
}
