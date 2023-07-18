using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void LevelChangeEvent();

public class LevellingComponent : MonoBehaviour
{
    public int CurrentLevel { get; private set; } = 1;

    public int m_currentXP;

    public int m_xpRequired = 10;

    public event LevelChangeEvent OnLevelUp;


    [SerializeField]
    private GameObject m_upgradeMenuUI;

    [SerializeField]
    private Scrollbar m_xpBar;

    void Start()
    {
        m_upgradeMenuUI.SetActive(false);
        GameManager.Instance.OnGameOver += (string reason) => m_upgradeMenuUI.SetActive(false);
    }

    public static LevellingComponent Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    public void AddXP(int xp)
    {
        m_currentXP += xp;

        if (m_currentXP >= m_xpRequired)
        {
            GameManager.Instance.PauseGame();
            m_upgradeMenuUI.SetActive(true);
            OnLevelUp.Invoke();
        }
    }

    void Update()
    {
        m_xpBar.size = (float)m_currentXP / (float)m_xpRequired;
    }

    public void ResetLevel()
    {
        m_currentXP = 0;
        m_upgradeMenuUI.SetActive(false);
        CurrentLevel++;
    }
}
