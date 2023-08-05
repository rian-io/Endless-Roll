using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public delegate void NewGame();
    public static event Action OnNewGame;

    public void StartNewGame()
    {
        OnNewGame?.Invoke();
    }
}
