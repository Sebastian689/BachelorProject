using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UITimer sceneTimer;
    public DeathCounter DC;
    public bool timerHasBegun = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BeginTimer()
    {
        sceneTimer.timerStarted = true;
        timerHasBegun = true;
    }

    public void RecieveDeath()
    {
        Debug.LogWarning("Made it to GM");
        DC.died = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
