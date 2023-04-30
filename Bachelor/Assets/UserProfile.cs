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
            profile = false;
        }

        ShowHint();
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

    public void ShowHint()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level2":
                HintWindow.SetActive(true);
                hintText.text = "You gain bonus score when picking up coins";
                break;
            case "Level3":
                HintWindow.SetActive(true);
                hintText.text = "Watch out for the monsters since they will eat the potato if they get too close";
                break;
        }
    }

    public void CloseHint()
    {
        HintWindow.SetActive(false);
    }
}
