using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI m_timerText;

    public float CurrentTime {get; private set;}

    void Start()
    {
        CurrentTime = GameManager.Instance.Settings.STARTING_TIME;
    }

    void Update()
    {
        CurrentTime -= Time.deltaTime;

        m_timerText.text = TimeSpan.FromSeconds(CurrentTime).ToString(@"mm\:ss");
    }

    public void AddTime(float additional)
    {
        CurrentTime += additional;
    }

}
