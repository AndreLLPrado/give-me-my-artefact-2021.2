using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;

public class Timer : MonoBehaviour
{
    public float timer; //time in seconds
    public bool timeOver;
    public bool startTimer;
    public GameObject timerPanel;
    void Start()
    {
        timeOver = false;
        startTimer = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //startTimer = true;
        }
        if (!timeOver && startTimer)
        {
            runTimer();
        }

        //timerPanel.GetComponent<TextEditor>().text = timer.ToString();
    }

    public void runTimer()
    {
        timer -= 1f * Time.deltaTime;

        if(timer <= 0f)
        {
            timeOver = true;
        }
    }
}
