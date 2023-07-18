using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI m_timerText;

    public float CurrentTime { get; private set; }

    public bool Active {get;set;}

    void Start()
    {
        CurrentTime = GameManager.Instance.Settings.STARTING_TIME;
    }

    void Update()
    {
        m_timerText.text = TimeSpan.FromSeconds(CurrentTime).ToString(@"mm\:ss");
        if(!Active) return;
        CurrentTime -= Time.deltaTime;


        if (CurrentTime <= 0)
        {
            GameManager.Instance.GameOver("Out of time");
        }
    }

    public void AddTime(float additional)
    {
        CurrentTime += additional;
    }

}
