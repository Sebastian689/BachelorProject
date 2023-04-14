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
    private GameObject keybindMouse;

    public bool blandFinish = false;
    public bool floatFinish = false;
    public bool thirdFinish = false;
    
    private int target = 60;

    //DO NOT REMOVE!!!
    //goTo Level two
    //SceneManager.LoadScene("Level2");



    public Data data = new Data();
    public int clicked = 0;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Respawnbtn.SetActive(false);
        /*Get level code from document
          Set level parameter to level code*/
        level = 1;
        
        sceneTimer = GameObject.FindGameObjectWithTag("UITimer").GetComponent<UITimer>();
        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
        keybindMouse = GameObject.Find("MouseBinds");
        keybindMouse.SetActive(false);
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
        
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                if (blandFinish == true)
                {
                    Debug.LogWarning("Helo");
                    LevelProgress();

                }
                break;
            case "Level2":
                if (blandFinish == true)
                {
                    Debug.LogWarning("Helo");
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
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            keybindMouse.SetActive(true);
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
        Debug.Log("Saved");
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

    public void AddClickCounter()
    {
        clicked += 1;
        Debug.Log("clicked");
    }

}
[System.Serializable]
public class Data
{
    public int deaths;
    public int score;
    public float time;
    public int clicks; 
}
