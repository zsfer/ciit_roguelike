using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public bool IsPaused { get; private set; }

    [SerializeField]
    private TextMeshProUGUI m_gameOverText;

    public static GameManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Timer = GetComponent<Timer>();
        m_gameOverText.gameObject.SetActive(false);
    }


    public void PauseGame() => IsPaused = true;

    public void GameOver(string reason)
    {
        OnGameOver.Invoke(reason ?? "Game over");

        m_gameOverText.gameObject.SetActive(true);
        m_gameOverText.text = reason ?? "Game over";
    }

}
