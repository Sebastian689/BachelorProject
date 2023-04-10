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

    //DO NOT REMOVE!!!
    //goTo Level two
    //SceneManager.LoadScene("Level2");



    // Start is called before the first frame update
    void Start()
    {
        Respawnbtn.SetActive(false);
        /*Get level code from document
          Set level parameter to level code*/
        level = 1;
        
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


    public void LevelProgress()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("Level3");
                break;
            case "Level3":
                SceneManager.LoadScene("Level4");
                break;
            case "Level4":
                SceneManager.LoadScene("Level5");
                break;
            case "Level5":
                SceneManager.LoadScene("The End");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                if(blandFinish == true)
                {
                    LevelProgress();
                }
                break;
            case "Level2":
                if (blandFinish == true)
                {
                    LevelProgress();
                }
                break;
            case "Level3":
                if (blandFinish == true)
                {
                    LevelProgress();
                }
                break;
            case "Level4":
                if (blandFinish == true)
                {
                    LevelProgress();
                }
                break;
            case "Level5":
                if (blandFinish == true)
                {
                    LevelProgress();
                }
                break;
        }
    }

    public void Score()
    {
        double points = 1000;
        float time = sceneTimer.currentTime;
        float deaths = DC.currentNum;
        // Extra points

        //Death calc

        double deathMult;
        if(deaths == 0)
        {
            deathMult = 0.5f;
        }
        else
        {
            deathMult = (1 + (0.1 * deaths));
        }

        points = points * deathMult;





    }
}
