using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UserProfile : MonoBehaviour
{
    public Accumulate accumulate;
    public GameObject UserProfileWindow;
    public GameObject HintWindow;
    
    public TMP_Text hintText;

    private bool profile;
    private bool hint2;
    private bool hint3;

    private static UserProfile instance;
    
    private bool showHint2 = true;
    private bool showHint3 = true;

    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UserProfileWindow = GameObject.FindGameObjectWithTag("UserProfile");
        HintWindow = GameObject.FindGameObjectWithTag("Hint");
        hintText = GameObject.FindGameObjectWithTag("HintText").GetComponent<TMP_Text>();
        accumulate = GameObject.FindGameObjectWithTag("Accumulate").GetComponent<Accumulate>();
        CloseHint();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("User has experience = " + profile);
        if (profile && accumulate.deaths >= 10 || profile && accumulate.timer >= 120.0f)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    profile = false;
                    hint2 = true;
                    break;
                case "Level2":
                    profile = false;
                    hint3 = true;
                    break;
            }
        }

        if (!profile)
        {
            ShowHint();
        }
    }

    public void ShowHint()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level2":
                if (showHint2 && hint2)
                {
                    HintWindow.SetActive(true);
                    hintText.text = "You gain bonus score when picking up coins";
                    showHint2 = false;
                }
                break;
            case "Level3":
                if (showHint3 && hint3)
                {
                    HintWindow.SetActive(true);
                    hintText.text = "Watch out for the monsters since they will eat the potato if they get too close";
                    showHint3 = false;
                }
                break;
        }
    }
    
    public void Experienced()
    {
        UserProfileWindow.SetActive(false);
        profile = true;
    }
    
    public void NoExperienced()
    {
        UserProfileWindow.SetActive(false);
        profile = false;
    }
    
    public void CloseHint()
    {
        HintWindow.SetActive(false);
    }
}
