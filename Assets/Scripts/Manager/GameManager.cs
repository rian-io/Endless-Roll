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
        MainMenu.OnNewGame += onStartGame;
        Player.OnPlayerDies += onGameOver;
    }

    private void OnDisable()
    {
        MainMenu.OnNewGame -= onStartGame;
        Player.OnPlayerDies -= onGameOver;
    }

    private void onStartGame()
    {
        Debug.Log("Game State = PLAYING");
        SceneManager.LoadScene(_gameSceneIndex);
    }

    private void onPaused(bool paused)
    {
        Debug.Log("Game State = PAUSE");
        Time.timeScale = paused ? 0f : 1f;
    }

    private void onGameOver()
    {
        Debug.Log("Game State = GAME OVER");
        SceneManager.LoadScene(_titleSceneIndex);
    }
}
