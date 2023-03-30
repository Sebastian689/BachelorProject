using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UITimer sceneTimer;
    public DeathCounter DC;
    public bool timerHasBegun = false;
    float cooldown = 3;

    public GameObject Startbtn;
    public GameObject Respawnbtn;

    // Start is called before the first frame update
    void Start()
    {
        Respawnbtn.SetActive(false);
    }

    public void BeginTimer()
    {
        if (Startbtn.activeInHierarchy | Respawnbtn.activeInHierarchy)
        {
            Startbtn.SetActive(false);
            Respawnbtn.SetActive(false);
        }
        


        
            sceneTimer.timerStarted = true;
            timerHasBegun = true;
    

   
    }

    public void RecieveDeath()
    {
        Respawnbtn.SetActive(true);
        Debug.LogWarning("Made it to GM");
        DC.died = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
