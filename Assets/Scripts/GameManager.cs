using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _titleSceneIndex = 0;
    private int _gameSceneIndex = 1;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        MainMenu.OnNewGame += OnStartGame;

        UIController.OnPause += OnPause;
        UIController.OnExitToMainMenu += OnExitToMainMenu;
        UIController.OnRestartGameAction += OnStartGame;
    }

    private void OnDisable()
    {
        MainMenu.OnNewGame -= OnStartGame;

        UIController.OnPause -= OnPause;
        UIController.OnExitToMainMenu -= OnExitToMainMenu;
        UIController.OnRestartGameAction -= OnStartGame;
    }

    private void OnStartGame()
    {
        Debug.Log("Game State = PLAYING");
        SceneManager.LoadScene(_gameSceneIndex);
    }

    private void OnPause(bool paused)
    {
        string state = paused ? "PAUSE" : "PLAYING";
        Debug.Log("Game State = " + state);
        Time.timeScale = paused ? 0f : 1f;
    }

    private void OnExitToMainMenu()
    {
        Debug.Log("Game State = MAIN MENU");
        OnPause(false); // Set the time scale to 1.

        SceneManager.LoadScene(_titleSceneIndex);
    }
}
