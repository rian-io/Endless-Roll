using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("HUD Data")]
    [SerializeField] HUDData hudData;

    [SerializeField] TMP_Text angleText;

    private void Update()
    {
        angleText.text = hudData.getLevelAngle();
    }
}
