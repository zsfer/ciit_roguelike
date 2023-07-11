using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevellingComponent : MonoBehaviour
{
    public int CurrentLevel { get; private set; } = 1;

    public int m_currentXP;

    public int m_xpGrowthRate = 5;


    [SerializeField]
    private GameObject m_upgradeMenuUI;

    [SerializeField]
    private Scrollbar m_xpBar;

    int m_xpRequired => Mathf.CeilToInt(CurrentLevel + Mathf.Pow(m_xpGrowthRate, 1.4f));

    void Start()
    {
        m_upgradeMenuUI.SetActive(false);
    }

    public static LevellingComponent Instance {get; private set;}
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
    }
}
