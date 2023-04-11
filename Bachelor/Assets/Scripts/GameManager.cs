using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UITimer sceneTimer;
    public DeathCounter DC;
    public bool timerHasBegun = false;

    public Data data = new Data();
    public int clicked = 0;

    // Start is called before the first frame update
    void Start()
    {
        sceneTimer = GameObject.FindGameObjectWithTag("UITimer").GetComponent<UITimer>();
        DC = GameObject.FindGameObjectWithTag("DeathCounter").GetComponent<DeathCounter>();
    }// Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }
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
