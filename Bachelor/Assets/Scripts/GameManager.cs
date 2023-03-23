using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UITimer sceneTimer;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
