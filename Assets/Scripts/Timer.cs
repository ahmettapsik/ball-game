using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isTimerOn;
    public float time;
    public TextMeshPro timerText;

    public static Timer instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void Update()
    {
        if (!isTimerOn)
            return;

        time -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string timer = string.Format("{00} : {1:00}", minutes, seconds);

        timerText.text = timer;

        if (time <= 0)
        {

        }
    }
}
