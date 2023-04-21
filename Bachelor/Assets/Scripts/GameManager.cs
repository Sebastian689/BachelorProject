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
    public GameObject hint;
    public GameObject decision;
    public UserProfiles userProfile;
    public int showHint;

    public bool blandFinish = false;
    public bool floatFinish = false;
    public bool thirdFinish = false;
    
    
    private int target = 60;

    public int coinCount;

    public TMP_Text scoreText;
    public GameObject scoreHolder;

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
        //UserProfile();
        Debug.LogError("I started");
        coinCount = 0;
        //Respawnbtn.SetActive(false);
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TMP_Text>();
        scoreHolder = GameObject.FindGameObjectWithTag("scoreText");
        endPanel = GameObject.FindGameObjectWithTag("EndPanel");
        endPanel.SetActive(false);

        sceneTimer = GameObject.FindGameObjectWithTag("UITimer").GetComponent<UITimer>();
        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();

        
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
        data.deaths = DC.currentNum;
        data.time = sceneTimer.currentTime;
        data.clicks = clicked;

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

    // Run in the Start method to find the two windows and setting the hint window to false because it will not be used in level 1
    public void UserProfile()
    {
        hint = GameObject.FindGameObjectWithTag("Hint");
        decision = GameObject.FindGameObjectWithTag("UserProfileChoice");
        hint.SetActive(false);
        decision.SetActive(true);
    }
    
    public void ShowHint(int specificHint)
    {
        hint = GameObject.FindGameObjectWithTag("Hint");
        decision = GameObject.FindGameObjectWithTag("UserProfileChoice");
        hint.SetActive(false);
        decision.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }
        if (halt != true) { 
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    if (blandFinish == true)
                    {
                        Score();
                        EndLevel();
                        halt = true;
                    }
                    break;
                case "Level2":
                    if (blandFinish == true)
                    {
                        Score();
                        EndLevel();
                        halt = true;
                    }
                    break;
                case "Level3":
                    if (blandFinish == true)
                    {
                        Score();
                        EndLevel();
                        halt = true;
                    }
                    break;
                case "Level4":
                    if (blandFinish == true)
                    {
                        Score();
                        EndLevel();
                        halt = true;
                    }
                    break;
                case "Level5":
                    if (blandFinish == true)
                    {
                        Score();
                        EndLevel();
                        halt = true;
                    }
                    break;
            }
    }
    }

    public void SaveToJson()
    {
        data.deaths = DC.currentNum;
        data.time = sceneTimer.currentTime;
        data.clicks = clicked;

        string parameterData = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/UserData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, parameterData);

    }

    public void Score()
    {
        double points = 1000;
        double time = sceneTimer.currentTime;

        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
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


        scoreText.text = score.ToString();

    }

    public void AddClickCounter()
    {
        clicked += 1;
    }


    public void EndLevel()
    {
        endPanel.SetActive(true);
        timerHasBegun = false;
        
    }
}
[System.Serializable]
public struct Data
{
    public int deaths;
    public int score;
    public float time;
    public int clicks; 
}




