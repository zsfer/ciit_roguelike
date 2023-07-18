using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool m_gameOver = false;

    [SerializeField]
    private TextMeshProUGUI m_gameOverText;

    [SerializeField]
    private GameObject m_enemyPrefab;

    public static GameManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Timer = GetComponent<Timer>();
        m_gameOverText.gameObject.SetActive(false);

        LevellingComponent.Instance.OnLevelUp += () => SpawnTrap(false, 1);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mod) {
        SpawnTrap(true, 4);
    }


    public void PauseGame() => IsPaused = true;

    public void GameOver(string reason)
    {
        OnGameOver.Invoke(reason ?? "Game over");

        m_gameOverText.gameObject.SetActive(true);
        m_gameOverText.text = $"<color=red>{reason}</color>" + "\nPress R to restart";
        m_gameOver = true;
    }

    private void Update() {
        if (m_gameOver && Input.GetKeyUp(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SpawnTrap(bool force, int count)
    {
        if (LevellingComponent.Instance.CurrentLevel % 5 == 0 || force) {
            for (int i = 0; i < count; i++)
            {
                Instantiate(m_enemyPrefab, RandomPos(), Quaternion.identity);
            }
        }
    }

    Vector3 RandomPos() => new Vector3(UnityEngine.Random.Range(-7.5f, 7.5f), UnityEngine.Random.Range(-3.5f, 4.0f), 0);

}
