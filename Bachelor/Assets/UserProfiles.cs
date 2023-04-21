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
        
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    CloseHint();
                    break;
                case "Level2":
                    OpenHint();
                    hintText.text = "The coins can be picked up for bonus score";
                    break;
                case "Level3":
                    OpenHint();
                    hintText.text = "Watch out for the monsters they will eat the potato if they come close enough";
                    break;
                case "Level4":
                    CloseHint();
                    break;
                case "Level5":
                    CloseHint();
                    break;
            }
        
    }
    
    public void CloseHint()
    {
        Hint.SetActive(false);
    }
    
    public void OpenHint()
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
