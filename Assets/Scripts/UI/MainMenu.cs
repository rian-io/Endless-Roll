using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public delegate void NewGame();
    public static event NewGame OnNewGame;

    public void StartNewGame()
    {
        OnNewGame?.Invoke();
    }
}
