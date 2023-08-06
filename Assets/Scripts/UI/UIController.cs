using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static event Action<bool> OnPause;

    public static event Action OnExitToMainMenu;

    [SerializeField] private GameObject _HUD;

    [SerializeField] private TMP_Text angleText;

    [SerializeField] private TMP_Text distanceText;

    [Space]

    [SerializeField] private GameObject _pauseMenu;

    [Space]

    [SerializeField] private GameObject _resumePanel;

    [SerializeField] private TMP_Text _countdownText;

    private bool _isPaused;

    private void Awake()
    {
        _isPaused = false;
        _resumePanel.SetActive(false);

        TogglePauseMenu();
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

    public void Pause()
    {
        _isPaused = !_isPaused;

        TogglePauseMenu();

        OnPause?.Invoke(_isPaused);
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _resumePanel.SetActive(true);

        StartCoroutine(CountdownResume());
    }

    public void ExitToMainMenu()
    {
        _isPaused = false;

        OnExitToMainMenu?.Invoke();
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

    private void TogglePauseMenu()
    {
        _HUD.SetActive(!_isPaused);

        _pauseMenu.SetActive(_isPaused);
    }

    private IEnumerator CountdownResume()
    {
        int countdown = 3;

        while (countdown > 0) {
            _countdownText.text = countdown.ToString();
            countdown--;

            yield return new WaitForSecondsRealtime(1);
        }

        _resumePanel.SetActive(false);

        Pause();
    }
}
