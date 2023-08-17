using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static event Action<bool> OnPause;

    public static event Action OnExitToMainMenu;

    public static event Action OnRestartGameAction;

    [Header("Panels")]
    [SerializeField] private GameObject _HUD;

    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private GameObject _resumePanel;

    [SerializeField] private GameObject _gameOverPanel;

    [Header("Texts")]
    [SerializeField] private TMP_Text _hudAngleText;

    [SerializeField] private TMP_Text _hudDistanceText;

    [SerializeField] private TMP_Text _gameOverAngleText;

    [SerializeField] private TMP_Text _gameOverDistanceText;

    [SerializeField] private TMP_Text _countdownText;

    private bool _isPaused;

    private void Awake()
    {
        _isPaused = false;
        _resumePanel.SetActive(false);
        _gameOverPanel.SetActive(false);

        TogglePauseMenu();
    }

    private void OnEnable()
    {
        HUDData.OnUpdateLevelAngle += UpdateLevelAngle;
        HUDData.OnUpdateLevelDistance += UpdateLevelDistance;

        Player.OnPlayerDies += GameOver;
    }

    private void OnDisable()
    {
        HUDData.OnUpdateLevelAngle -= UpdateLevelAngle;
        HUDData.OnUpdateLevelDistance -= UpdateLevelDistance;

        Player.OnPlayerDies -= GameOver;
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

    public void RestartGame()
    {
        _isPaused = false;

        OnRestartGameAction?.Invoke();
    }

    private void UpdateLevelAngle(float angle)
    {
        _hudAngleText.text = ConvertFloatToString(angle);
    }

    private void UpdateLevelDistance(float distance)
    {
        _hudDistanceText.text = ConvertFloatToString(distance);
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

    private void GameOver()
    {
        _HUD.SetActive(false);

        _gameOverAngleText.text = _hudAngleText.text + "º";
        _gameOverDistanceText.text = _hudDistanceText.text + "m";
        _gameOverPanel.SetActive(true);
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
