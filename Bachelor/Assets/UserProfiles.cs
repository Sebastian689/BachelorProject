using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserProfiles : MonoBehaviour
{
    
    public TMP_Text hintText;
    public GameObject Hint;
    public GameObject Decision;
    public string userProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        Hint = GameObject.FindGameObjectWithTag("Hint");
        Decision = GameObject.FindGameObjectWithTag("UserProfileChoice");
    }

    // Update is called once per frame
    void Update()
    {
        if (userProfile == "Experienced")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    hintText.text = "The Spring can be used to launch the potato up";
                    CloseWindow();
                    break;
                case "Level2":
                    hintText.text = "The coins can be picked up for bonus score";
                    OpenWindow();
                    break;
                case "Level3":
                    hintText.text = "Watch out for the monsters they will eat the potato if they come close enough";
                    OpenWindow();
                    break;
                case "Level4":
                    hintText.text = "The Traffic cone can be used to stop potato and make it turn around";
                    CloseWindow();
                    break;
                case "Level5":
                    hintText.text = "Watch out for the monsters they will eat the potato if they come close enough";
                    CloseWindow();
                    break;
            }
        }
    }
    
    public void CloseWindow()
    {
        Hint.SetActive(false);
    }
    
    public void OpenWindow()
    {
        Hint.SetActive(true);
    }
    
    public void NoExperience()
    {
        SetUserProfile("No Experience");
        Decision.SetActive(false);
    }
    
    public void Experienced()
    {
        SetUserProfile("Experienced");
        Decision.SetActive(false);
    }

    public void SetUserProfile(string String)
    {
        userProfile = String;
    }
}
