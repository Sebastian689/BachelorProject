using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    // start time value
    [SerializeField] float startTime;

    // current Time
    float currentTime;

    // whether the timer started?
    bool timerStarted = false;

    // ref var for my TMP text component
    [SerializeField] TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        //resets the currentTime to the start Time 
        currentTime = startTime;
        //displays the UI with the currentTime
        timerText.text = currentTime.ToString();
        // starts the time -- comment this out if you don't want to automagically start
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        // you are starting the timer at "Start", you can still use the A-button to restart it.
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentTime = startTime;
            timerStarted = true;
        }

        if (timerStarted)
        {
            // subtracting the previous frame's duration
            currentTime += Time.deltaTime;

            timerText.text = currentTime.ToString("f1");
        }
    }
}

