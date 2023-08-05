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
        HUDController.OnPauseAction += OnPause;

        Player.OnPlayerDies += OnGameOver;
    }

    private void OnDisable()
    {
        MainMenu.OnNewGame -= OnStartGame;
        HUDController.OnPauseAction -= OnPause;

        Player.OnPlayerDies -= OnGameOver;
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

    private void OnGameOver()
    {
        Debug.Log("Game State = GAME OVER");
        SceneManager.LoadScene(_titleSceneIndex);
    }
}
