using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameOverHandler(string reason);

[Serializable]
public class GameSettings
{
    public int MAX_PLAYER_HEALTH = 100;
    public float STARTING_TIME = 300;
}

public class GameManager : MonoBehaviour
{
    public event GameOverHandler OnGameOver;

    public GameSettings Settings;

    public Timer Timer { get; private set; }

    public bool IsPaused {get; private set;}

    public static GameManager Instance { get;set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Timer = GetComponent<Timer>();
    }
    

    public void PauseGame() => IsPaused = true;

    public void GameOver(string reason)
    {
        OnGameOver.Invoke(reason ?? "Game over");
    }

}
