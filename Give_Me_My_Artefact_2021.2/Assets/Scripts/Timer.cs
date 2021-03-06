using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine.UI;

public class Timer : NetworkBehaviour
{
    //public float timer; //time in seconds
    public NetworkVariableFloat timer; //time in seconds
    public NetworkVariableBool timeOver;
    public NetworkVariableBool startTimer;
    //public bool timeOver;
    //public bool startTimer;
    //public GameObject timerPanel;

    public Text timerTxt;
    //NetworkVariable<Text> score;
    
    void Start()
    {
        timeOver.Value = false;
        startTimer.Value = false;
        //timerTxt = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //startTimer.Value = true;
        }
        if (!timeOver.Value && startTimer.Value)
        {
            runTimer();
            timerTxt.text = timer.Value.ToString() + "s";
        }

        
    }

    public void runTimer()
    {
        timer.Value -= 1f * Time.deltaTime;

        if(timer.Value <= 0f)
        {
            timeOver.Value = true;
        }
    }

    public void StartTimer()
    {
        startTimer.Value = true;
    }
}
