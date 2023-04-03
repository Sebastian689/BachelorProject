using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UITimer sceneTimer;
    public DeathCounter DC;
    public bool timerHasBegun = false;
    //float cooldown = 3;
    public int level;

    public GameObject Startbtn;
    public GameObject Respawnbtn;

    public bool blandFinish = false;
    public bool floatFinish = false;
    public bool thirdFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        Respawnbtn.SetActive(false);
        /*Get level code from document
          Set level parameter to level code*/
        
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


    public void Finish(int Level)
    {
        int currentLevel = Level;

        switch (currentLevel){
            case 1:
                if (blandFinish == true)
                {
                    //goTo Level two
                    SceneManager.LoadScene("Level2");
                }
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
