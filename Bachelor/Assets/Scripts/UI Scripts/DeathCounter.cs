using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    // start time value
    [SerializeField] int startNum;

    // current Time
    int currentNum;

    // whether the timer started?
    public bool timerStarted = false;

    // checks death
    public bool died = false;

    // ref var for my TMP text component
    [SerializeField] TMP_Text numText;

    // Start is called before the first frame update
    void Start()
    {
        //resets the currentTime to the start Time 
        currentNum = startNum;
        //displays the UI with the currentTime
        numText.text = currentNum.ToString();

    }

    // Update is called once per frame
    void Update()
    {

      if (died == true)
        {
            Debug.LogWarning("Made it to DC");
            currentNum ++;
            numText.text = currentNum.ToString();
            died = false;
        }
    }
}