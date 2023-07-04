using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameOverHandler(string reason);

public class GameManager : MonoBehaviour
{
    public event GameOverHandler OnGameOver;

    public static GameManager Instance { get;set; }
    private void Awake()
    {
        Instance = this;
    }

    public void GameOver(string reason)
    {
        OnGameOver.Invoke(reason ?? "Game over");
    }

}
