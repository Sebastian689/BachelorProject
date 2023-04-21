using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject endPanel;
    public UITimer sceneTimer;
    public DeathCounter DC;
    public bool timerHasBegun = false;
    //float cooldown = 3;
    public bool halt = false;

    //public GameObject Startbtn;
    //public GameObject Respawnbtn;
    public GameObject keybindMouse;

    public bool blandFinish = false;
    public bool floatFinish = false;
    public bool thirdFinish = false;

    private int target = 60;

    public int coinCount;

    public TMP_Text scoreText;
    public GameObject scoreHolder;

    public Accumulate accum;

    public Data data = new Data();
    public int clicked = 0;

    bool isEnd = false;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("I started");
        coinCount = 0;
        //Respawnbtn.SetActive(false);
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TMP_Text>();
        //scoreHolder = GameObject.FindGameObjectWithTag("scoreText");
        //endPanel = GameObject.FindGameObjectWithTag("EndPanel");
        //endPanel.SetActive(false);
        endPanel = GameObject.FindGameObjectWithTag("EndPanel");
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TMP_Text>();
        sceneTimer = GameObject.FindGameObjectWithTag("UITimer").GetComponent<UITimer>();
        endPanel.SetActive(false);
        

        
        //DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
        accum = GameObject.FindGameObjectWithTag("Accumulate").GetComponent<Accumulate>();
        
        Debug.Log("Made it here");
    }


    public void BeginTimer()
    {
        sceneTimer = GameObject.FindGameObjectWithTag("UITimer").GetComponent<UITimer>();
        if (SceneManager.GetActiveScene().name != "TheEnd")
        {
            sceneTimer.timerStarted = true;
            timerHasBegun = true;

        } else
        {
            Debug.LogWarning("Is the end");
        }
   
    }

    public void RecieveDeath()
    {
        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
        if (SceneManager.GetActiveScene().name != "TheEnd")
        {
            //Respawnbtn.SetActive(true);
            DC.died = true;
        }
        Debug.LogWarning("Made it to GM");
        
    }


    public void LevelProgress()
    {
        //endPanel.SetActive(false);

        accum.deaths += DC.currentNum;
        accum.timer += sceneTimer.currentTime;
        accum.clicks += clicked;


        string parameterData = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/UserData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, parameterData);
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
                SceneManager.LoadScene("TheEnd");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
     
        if (SceneManager.GetActiveScene().name == "TheEnd" && isEnd == false)
        {
            Debug.LogWarning("IsEnd");
            isEnd = true;
            GameObject.FindGameObjectWithTag("RegUI").SetActive(false);
            
        }


        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;

        
        if (halt != true) { 
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    if (blandFinish == true)
                    {
                        EndLevel();
                        Score();
                        
                        halt = true;
                    }
                    break;
                case "Level2":
                    if (blandFinish == true)
                    {
                        
                        EndLevel();
                        Score();
                        halt = true;
                    }
                    break;
                case "Level3":
                    if (blandFinish == true)
                    {
                        EndLevel();
                        Score();
                        
                        halt = true;
                    }
                    break;
                case "Level4":
                    if (blandFinish == true)
                    {
                        EndLevel();
                        Score();
                        
                        halt = true;
                    }
                    break;
                case "Level5":
                    if (blandFinish == true)
                    {
                        EndLevel();
                        Score();
                        
                        halt = true;
                    }
                    break;
            }
    }
    }

    public void SaveToJson()
    {
       
        string parameterData = JsonUtility.ToJson(accum);
        string filePath = Application.persistentDataPath + "/UserData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, parameterData);

    }

    public void Score()
    {
        endPanel.SetActive(true);
        double points = 1000;
        double time = sceneTimer.currentTime;

        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
        //scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TMP_Text>();
        scoreHolder = GameObject.FindGameObjectWithTag("scoreText");
        int deaths = DC.currentNum;
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

        //Time calc
        double timeMult;
        timeMult = (time / 60);
        if (timeMult <= 1)
        {
            points = points / timeMult;
        }
        else
        {
            points = points * timeMult;
        }
        //Coin calc
        double coinScore = coinCount * 200;
        points = points + coinScore;

        float score = (float)points;
        //Cleanup
        score = Mathf.Round(score);
        //loggedScore = score;
        


        scoreText.text = score.ToString();
        accum.score += score;
        SaveToJson();
    }

    public void AddClickCounter()
    {
        clicked += 1;
    }


    public void EndLevel()
    {
        
        timerHasBegun = false;
        
    }
}
[System.Serializable]
public struct Data
{
    public int deaths;
    public float score;
    public float time;
    public int clicks; 
}




